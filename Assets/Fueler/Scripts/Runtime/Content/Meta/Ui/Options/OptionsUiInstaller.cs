using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using UnityEngine;
using Juce.CoreUnity.Ui.SelectableCallback;
using Juce.CoreUnity.Ui.Others;
using Fueler.Content.Meta.Ui.Options.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.SubscribeToButtons;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleFullscreenButtonPressed;
using Fueler.Contexts.Shared.UseCases.ApplyGameSettings;
using Fueler.Content.Services.Persistence;
using Juce.CoreUnity.ViewStack.Entries;

namespace Fueler.Content.Meta.Ui.Options
{
    public class OptionsUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks toggleFullscreenButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks backButton = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<IToggleFullscreenButtonPressedUseCase>()
                .FromFunction(c => new ToggleFullscreenButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    c.Resolve<IApplyGameSettingsUseCase>()
                    ));

            container.Bind<IBackButtonPressedUseCase>()
               .FromFunction(c => new BackButtonPressedUseCase(
                   c.Resolve<IUiViewStack>()
                   ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    toggleFullscreenButton,
                    backButton,
                    c.Resolve<IToggleFullscreenButtonPressedUseCase>(),
                    c.Resolve<IBackButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IOptionsUiInteractor>()
                .FromFunction(c => new OptionsUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(IOptionsUiInteractor),
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
