using Fueler.Content.Meta.Ui.Options.UseCases.AccessibilityButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioFxButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioMusicButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleFullscreenButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.Options.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks accessibilityButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleFullscreenButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleAudioFxButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleAudioMusicButton;
        private readonly PointerAndSelectableSubmitCallbacks backButton;
        private readonly IAccessibilityButtonPressedUseCase accessibilityButtonPressedUseCase;
        private readonly IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase;
        private readonly IToggleAudioFxButtonPressedUseCase toggleAudioFxButtonPressedUseCase;
        private readonly IToggleAudioMusicButtonPressedUseCase toggleAudioMusicButtonPressedUseCase;
        private readonly IBackButtonPressedUseCase backButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks accessibilityButton,
            PointerAndSelectableSubmitCallbacks toggleFullscreenButton,
            PointerAndSelectableSubmitCallbacks toggleAudioFxButton,
            PointerAndSelectableSubmitCallbacks toggleAudioMusicButton,
            PointerAndSelectableSubmitCallbacks backButton,
            IAccessibilityButtonPressedUseCase accessibilityButtonPressedUseCase,
            IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase,
            IToggleAudioFxButtonPressedUseCase toggleAudioFxButtonPressedUseCase,
            IToggleAudioMusicButtonPressedUseCase toggleAudioMusicButtonPressedUseCase,
            IBackButtonPressedUseCase backButtonPressedUseCase
            )
        {
            this.accessibilityButton = accessibilityButton;
            this.toggleFullscreenButton = toggleFullscreenButton;
            this.toggleAudioFxButton = toggleAudioFxButton;
            this.toggleAudioMusicButton = toggleAudioMusicButton;
            this.backButton = backButton;
            this.accessibilityButtonPressedUseCase = accessibilityButtonPressedUseCase;
            this.toggleFullscreenButtonPressedUseCase = toggleFullscreenButtonPressedUseCase;
            this.toggleAudioFxButtonPressedUseCase = toggleAudioFxButtonPressedUseCase;
            this.toggleAudioMusicButtonPressedUseCase = toggleAudioMusicButtonPressedUseCase;
            this.backButtonPressedUseCase = backButtonPressedUseCase;
        }

        public void Execute()
        {
            accessibilityButton.OnSubmit += accessibilityButtonPressedUseCase.Execute;
            toggleFullscreenButton.OnSubmit += toggleFullscreenButtonPressedUseCase.Execute;
            toggleAudioFxButton.OnSubmit += toggleAudioFxButtonPressedUseCase.Execute;
            toggleAudioMusicButton.OnSubmit += toggleAudioMusicButtonPressedUseCase.Execute;
            backButton.OnSubmit += backButtonPressedUseCase.Execute;
        }
    }
}
