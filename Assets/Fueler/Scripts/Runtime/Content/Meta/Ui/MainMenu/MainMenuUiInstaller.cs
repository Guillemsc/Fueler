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
using Fueler.Content.Meta.Ui.MainMenu.UseCases.QuitButtonPressed;
using Juce.Core.Refresh;
using Juce.CoreUnity.ViewStack.Entries;
using System.Collections.Generic;

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
        [SerializeField] private PointerAndSelectableSubmitCallbacks quitButton = default;

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

            container.Bind<IQuitButtonPressedUseCase>()
                .FromFunction(c => new QuitButtonPressedUseCase(
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    playButton,
                    optionsButton,
                    quitButton,
                    c.Resolve<IPlayButtonPressedUseCase>(),
                    c.Resolve<IOptionsButtonPressedUseCase>(),
                    c.Resolve<IQuitButtonPressedUseCase>()
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
                isPopup: false,
                new ViewStackEntryRefresh(RefreshType.BeforeShow, new SetAsSelectedRefreshable(firstSelectable))
                );
        }
    }
}
