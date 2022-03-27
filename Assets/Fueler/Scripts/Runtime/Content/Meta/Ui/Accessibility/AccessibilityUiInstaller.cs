using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using UnityEngine;
using Juce.CoreUnity.Ui.SelectableCallback;
using Juce.CoreUnity.Ui.Others;
using Fueler.Content.Services.Persistence;
using Juce.CoreUnity.ViewStack.Entries;
using Juce.Core.Refresh;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.SubscribeToButtons;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteFuelToggleText;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteTimeToggleText;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.InitFromPersistence;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.ToggleInfiniteFuelButtonPressed;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.ToggleInfiniteTimeButtonPressed;

namespace Fueler.Content.Meta.Ui.Accessibility
{
    public class AccessibilityUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks toggleUnlimitedFuelButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks toggleUnlimitedTimeButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks backButton = default;

        [Header("Unlimited Fuel")]
        [SerializeField] private TMPro.TextMeshProUGUI toggleUnlimitedFuelOnOffText = default;
        [SerializeField] private string unlimitedFuelTextEnabled = default;
        [SerializeField] private string unlimitedFuelTextDisabled = default;

        [Header("Unlimited Time")]
        [SerializeField] private TMPro.TextMeshProUGUI toggleUnlimitedTimeOnOffText = default;
        [SerializeField] private string unlimitedTimeTextEnabled = default;
        [SerializeField] private string unlimitedTimeTextDisabled = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<AccessibilityUiViewStackEntry>()
                .FromFunction(c => new AccessibilityUiViewStackEntry(
                    typeof(IAccessibilityUiInteractor),
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
                        new CallbackRefreshable(c.Resolve<IInitFromPersistenceUseCase>().Execute)
                        )
                    ));

            container.Bind<IInitFromPersistenceUseCase>()
                .FromFunction(c => new InitFromPersistenceUseCase(
                    c.Resolve<IUpdateInfiniteFuelToggleTextUseCase>(),
                    c.Resolve<IUpdateInfiniteTimeToggleTextUseCase>()
                    ));

            container.Bind<IUpdateInfiniteFuelToggleTextUseCase>()
                .FromFunction(c => new UpdateInfiniteFuelToggleTextUseCase(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable,
                    toggleUnlimitedFuelOnOffText,
                    unlimitedFuelTextEnabled,
                    unlimitedFuelTextDisabled
                    ));

            container.Bind<IUpdateInfiniteTimeToggleTextUseCase>()
                .FromFunction(c => new UpdateInfiniteTimeToggleTextUseCase(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable,
                    toggleUnlimitedTimeOnOffText,
                    unlimitedTimeTextEnabled,
                    unlimitedTimeTextDisabled
                    ));

            container.Bind<IToggleInfiniteFuelButtonPressedUseCase>()
                .FromFunction(c => new ToggleInfiniteFuelButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable,
                    c.Resolve<IUpdateInfiniteFuelToggleTextUseCase>()
                    ));

            container.Bind<IToggleInfiniteTimeButtonPressedUseCase>()
                .FromFunction(c => new ToggleInfiniteTimeButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable,
                    c.Resolve<IUpdateInfiniteTimeToggleTextUseCase>()
                    ));

            container.Bind<IBackButtonPressedUseCase>()
               .FromFunction(c => new BackButtonPressedUseCase(
                   c.Resolve<IUiViewStack>()
                   ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    toggleUnlimitedFuelButton,
                    toggleUnlimitedTimeButton,
                    backButton,
                    c.Resolve<IToggleInfiniteFuelButtonPressedUseCase>(),
                    c.Resolve<IToggleInfiniteTimeButtonPressedUseCase>(),
                    c.Resolve<IBackButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IAccessibilityUiInteractor>()
                .FromFunction(c => new AccessibilityUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(c.Resolve<AccessibilityUiViewStackEntry>()))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(c.Resolve<AccessibilityUiViewStackEntry>()))
                .NonLazy();
        }
    }
}
