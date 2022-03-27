using Fueler.Content.Meta.Ui.Options.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioFxButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioMusicButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleFullscreenButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.Options.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks toggleFullscreenButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleAudioFxButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleAudioMusicButton;
        private readonly PointerAndSelectableSubmitCallbacks backButton;
        private readonly IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase;
        private readonly IToggleAudioFxButtonPressedUseCase toggleAudioFxButtonPressedUseCase;
        private readonly IToggleAudioMusicButtonPressedUseCase toggleAudioMusicButtonPressedUseCase;
        private readonly IBackButtonPressedUseCase backButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks toggleFullscreenButton,
            PointerAndSelectableSubmitCallbacks toggleAudioFxButton,
            PointerAndSelectableSubmitCallbacks toggleAudioMusicButton,
            PointerAndSelectableSubmitCallbacks backButton,
            IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase,
            IToggleAudioFxButtonPressedUseCase toggleAudioFxButtonPressedUseCase,
            IToggleAudioMusicButtonPressedUseCase toggleAudioMusicButtonPressedUseCase,
            IBackButtonPressedUseCase backButtonPressedUseCase
            )
        {
            this.toggleFullscreenButton = toggleFullscreenButton;
            this.toggleAudioFxButton = toggleAudioFxButton;
            this.toggleAudioMusicButton = toggleAudioMusicButton;
            this.backButton = backButton;
            this.toggleFullscreenButtonPressedUseCase = toggleFullscreenButtonPressedUseCase;
            this.toggleAudioFxButtonPressedUseCase = toggleAudioFxButtonPressedUseCase;
            this.toggleAudioMusicButtonPressedUseCase = toggleAudioMusicButtonPressedUseCase;
            this.backButtonPressedUseCase = backButtonPressedUseCase;
        }

        public void Execute()
        {
            toggleFullscreenButton.OnSubmit += toggleFullscreenButtonPressedUseCase.Execute;
            toggleAudioFxButton.OnSubmit += toggleAudioFxButtonPressedUseCase.Execute;
            toggleAudioMusicButton.OnSubmit += toggleAudioMusicButtonPressedUseCase.Execute;
            backButton.OnSubmit += backButtonPressedUseCase.Execute;
        }
    }
}
