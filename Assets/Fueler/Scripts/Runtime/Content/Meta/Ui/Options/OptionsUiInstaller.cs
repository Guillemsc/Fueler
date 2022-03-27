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
using Fueler.Content.Meta.Ui.Options.UseCases.InitFromPersistence;
using Juce.Core.Refresh;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioFxButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioMusicButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioFxToggleText;
using Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioMusicToggleText;

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
        [SerializeField] private PointerAndSelectableSubmitCallbacks toggleAudioFxButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks toggleAudioMusicButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks backButton = default;

        [Header("Audio Fx")]
        [SerializeField] private TMPro.TextMeshProUGUI toggleAudioFxOnOffText = default;
        [SerializeField] private string audioFxTextEnabled = default;
        [SerializeField] private string audioFxTextDisabled = default;

        [Header("Audio Musix")]
        [SerializeField] private TMPro.TextMeshProUGUI toggleAudioMusicOnOffText = default;
        [SerializeField] private string audioMusicTextEnabled = default;
        [SerializeField] private string audioMusicTextDisabled = default;

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
                    c.Resolve<IUpdateAudioFxToggleTextUseCase>(),
                    c.Resolve<IUpdateAudioMusicToggleTextUseCase>()
                    ));

            container.Bind<IUpdateAudioFxToggleTextUseCase>()
                .FromFunction(c => new UpdateAudioFxToggleTextUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    toggleAudioFxOnOffText,
                    audioFxTextEnabled,
                    audioFxTextDisabled
                    ));

            container.Bind<IUpdateAudioMusicToggleTextUseCase>()
                .FromFunction(c => new UpdateAudioMusicToggleTextUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    toggleAudioMusicOnOffText,
                    audioMusicTextEnabled,
                    audioMusicTextDisabled
                    ));

            container.Bind<IToggleFullscreenButtonPressedUseCase>()
                .FromFunction(c => new ToggleFullscreenButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    c.Resolve<IApplyGameSettingsUseCase>()
                    ));

            container.Bind<IToggleAudioFxButtonPressedUseCase>()
                .FromFunction(c => new ToggleAudioFxButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    c.Resolve<IApplyGameSettingsUseCase>(),
                    c.Resolve<IUpdateAudioFxToggleTextUseCase>()
                    ));

            container.Bind<IToggleAudioMusicButtonPressedUseCase>()
                .FromFunction(c => new ToggleAudioMusicButtonPressedUseCase(
                    c.Resolve<IPersistenceService>().GameSettingsSerializable,
                    c.Resolve<IApplyGameSettingsUseCase>(),
                    c.Resolve<IUpdateAudioMusicToggleTextUseCase>()
                    ));

            container.Bind<IBackButtonPressedUseCase>()
               .FromFunction(c => new BackButtonPressedUseCase(
                   c.Resolve<IUiViewStack>()
                   ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    toggleFullscreenButton,
                    toggleAudioFxButton,
                    toggleAudioMusicButton,
                    backButton,
                    c.Resolve<IToggleFullscreenButtonPressedUseCase>(),
                    c.Resolve<IToggleAudioFxButtonPressedUseCase>(),
                    c.Resolve<IToggleAudioMusicButtonPressedUseCase>(),
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
