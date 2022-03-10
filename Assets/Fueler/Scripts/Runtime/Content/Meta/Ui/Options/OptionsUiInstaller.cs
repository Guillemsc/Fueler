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
using Fueler.Content.Meta.Ui.Options.UseCases.InfiniteFuelOnOffButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.AudioOnOffButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.UpdateInfiniteFuelOnOffText;
using Fueler.Content.Meta.Ui.Options.UseCases.InitFromPersistence;
using Juce.Core.Refresh;

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
        [SerializeField] private PointerAndSelectableSubmitCallbacks infiniteFuelOnOffButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks toggleFullscreenButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks audioOnOffButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks backButton = default;

        [Header("InfiniteFuel")]
        [SerializeField] private TMPro.TextMeshProUGUI infiniteFuelOnOffText = default;
        [SerializeField] private string infiniteFuelTextOn = default;
        [SerializeField] private string infiniteFuelTextOff = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<OptionsUiViewStackEntry>()
                .FromFunction(c => new OptionsUiViewStackEntry(
                    typeof(IOptionsUiInteractor),
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
                    c.Resolve<IUpdateInfiniteFuelOnOffTextUseCase>()
                    ));

            container.Bind<IUpdateInfiniteFuelOnOffTextUseCase>()
                .FromFunction(c => new UpdateInfiniteFuelOnOffTextUseCase(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable,
                    infiniteFuelOnOffText,
                    infiniteFuelTextOn,
                    infiniteFuelTextOff
                    ));

            container.Bind<IInfiniteFuelOnOffButtonPressedUseCase>()
                .FromFunction(c => new InfiniteFuelOnOffButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable,
                    c.Resolve<IUpdateInfiniteFuelOnOffTextUseCase>()
                    ));

            container.Bind<IToggleFullscreenButtonPressedUseCase>()
                .FromFunction(c => new ToggleFullscreenButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    c.Resolve<IApplyGameSettingsUseCase>()
                    ));

            container.Bind<IAudioOnOffButtonPressedUseCase>()
                .FromFunction(c => new AudioOnOffButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable
                    ));

            container.Bind<IBackButtonPressedUseCase>()
               .FromFunction(c => new BackButtonPressedUseCase(
                   c.Resolve<IUiViewStack>()
                   ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    infiniteFuelOnOffButton,
                    toggleFullscreenButton,
                    audioOnOffButton,
                    backButton,
                    c.Resolve<IInfiniteFuelOnOffButtonPressedUseCase>(),
                    c.Resolve<IToggleFullscreenButtonPressedUseCase>(),
                    c.Resolve<IAudioOnOffButtonPressedUseCase>(),
                    c.Resolve<IBackButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IOptionsUiInteractor>()
                .FromFunction(c => new OptionsUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(c.Resolve<OptionsUiViewStackEntry>()))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(c.Resolve<OptionsUiViewStackEntry>()))
                .NonLazy();
        }
    }
}
