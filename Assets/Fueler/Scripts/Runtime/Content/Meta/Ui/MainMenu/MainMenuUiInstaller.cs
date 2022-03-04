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
using Fueler.Content.Services.Configuration;

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
        [SerializeField] private PointerAndSelectableSubmitCallbacks optionsButton = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<ITryGetLevelByIndexUseCase>()
                .FromFunction(c => new TryGetLevelByIndexUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<IPlayButtonPressedUseCase>()
                .FromFunction(c => new PlayButtonPressedUseCase(
                    c.Resolve<ITryGetLevelByIndexUseCase>(),
                    c.Resolve<IUnloadMetaAndLoadStageUseCase>()
                    ));

            container.Bind<IOptionsButtonPressedUseCase>()
                .FromFunction(c => new OptionsButtonPressedUseCase(
                    c.Resolve<IUiViewStack>()
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    playButton,
                    optionsButton,
                    c.Resolve<IPlayButtonPressedUseCase>(),
                    c.Resolve<IOptionsButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IMainMenuUiInteractor>()
                .FromFunction(c => new MainMenuUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(IMainMenuUiInteractor),
                gameObject.transform,
                new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ),
                new SetAsSelectedRefreshable(firstSelectable),
                isPopup: false
                );
        }
    }
}
