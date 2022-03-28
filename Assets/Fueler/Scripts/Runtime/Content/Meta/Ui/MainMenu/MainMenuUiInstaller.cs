using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.Ui.Others;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using UnityEngine;
using Juce.CoreUnity.Ui.SelectableCallback;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.SubscribeToButtons;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.OptionsButtonPressed;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.PlayButtonPressed;
using Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.QuitButtonPressed;
using Juce.CoreUnity.ViewStack.Entries;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.LevelsButtonPressed;
using Fueler.Content.Shared.Levels.UseCases.IsFirstTimeExperience;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.RefreshFirstTimeExperience;
using Juce.Core.Refresh;
using Fueler.Content.Shared.Levels.UseCases.GetLastPlayedLevel;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;

namespace Fueler.Content.Meta.Ui.MainMenu
{
    public class MainMenuUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks playButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks levelsButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks optionsButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks quitButton = default;

        [Header("First Time User Experience")]
        [SerializeField] private TMPro.TextMeshProUGUI playButtonText = default;
        [SerializeField] private GameObject levelsButtonGameObject = default;
        [SerializeField] private string firstTimeExperiencePlayText = default;
        [SerializeField] private string nonFirstTimeExperiencePlayText = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<MainMenuUiViewStackEntry>()
                .FromFunction(c => new MainMenuUiViewStackEntry(
                    typeof(IMainMenuUiInteractor),
                    gameObject.transform,
                    new TweenPlayerAnimationVisible(
                        showAnimation,
                        hideAnimation
                        ),
                    isPopup: false,
                    new ViewStackEntryRefresh(
                        RefreshType.BeforeShow,
                        new SetAsSelectedRefreshable(firstSelectable)
                        ),
                    new ViewStackEntryRefresh(
                        RefreshType.BeforeShow,
                        new CallbackRefreshable(
                            c.Resolve<IRefreshFirstTimeExperienceUseCase>().Execute
                            )
                        )
                    ));

            container.Bind<IPlayButtonPressedUseCase>()
                .FromFunction(c => new PlayButtonPressedUseCase(
                    c.Resolve<ITryGetLevelByIndexUseCase>(),
                    c.Resolve<IIsFirstTimeExperienceUseCase>(),
                    c.Resolve<IGetLastPlayedLevelUseCase>(),
                    c.Resolve<ITryGetLevelIndexByLevelIdUseCase>(),
                    c.Resolve<IUnloadMetaAndLoadStageUseCase>()
                    ));

            container.Bind<ILevelsButtonPressedUseCase>()
                .FromFunction(c => new LevelsButtonPressedUseCase(
                    c.Resolve<IUiViewStack>()
                    ));

            container.Bind<IOptionsButtonPressedUseCase>()
                .FromFunction(c => new OptionsButtonPressedUseCase(
                    c.Resolve<IUiViewStack>()
                    ));

            container.Bind<IQuitButtonPressedUseCase>()
                .FromFunction(c => new QuitButtonPressedUseCase(
                    ));

            container.Bind<IRefreshFirstTimeExperienceUseCase>()
                .FromFunction(c => new RefreshFirstTimeExperienceUseCase(
                    playButtonText,
                    levelsButtonGameObject,
                    firstTimeExperiencePlayText,
                    nonFirstTimeExperiencePlayText,
                    c.Resolve<IIsFirstTimeExperienceUseCase>()
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    playButton,
                    levelsButton,
                    optionsButton,
                    quitButton,
                    c.Resolve<IPlayButtonPressedUseCase>(),
                    c.Resolve<ILevelsButtonPressedUseCase>(),
                    c.Resolve<IOptionsButtonPressedUseCase>(),
                    c.Resolve<IQuitButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IMainMenuUiInteractor>()
                .FromFunction(c => new MainMenuUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(c.Resolve<MainMenuUiViewStackEntry>()))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(c.Resolve<MainMenuUiViewStackEntry>()))
                .NonLazy();
        }
    }
}
