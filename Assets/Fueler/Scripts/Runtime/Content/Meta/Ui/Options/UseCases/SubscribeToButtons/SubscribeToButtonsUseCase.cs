using Fueler.Content.Meta.Ui.Options.UseCases.AudioOnOffButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.InfiniteFuelOnOffButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleFullscreenButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.Options.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks infiniteFuelOnOffButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleFullscreenButton;
        private readonly PointerAndSelectableSubmitCallbacks audioOnOffButton;
        private readonly PointerAndSelectableSubmitCallbacks backButton;
        private readonly IInfiniteFuelOnOffButtonPressedUseCase infiniteFuelOnOffButtonPressedUseCase;
        private readonly IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase;
        private readonly IAudioOnOffButtonPressedUseCase audioOnOffButtonPressedUseCase;
        private readonly IBackButtonPressedUseCase backButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks infiniteFuelOnOffButton,
            PointerAndSelectableSubmitCallbacks toggleFullscreenButton,
            PointerAndSelectableSubmitCallbacks audioOnOffButton,
            PointerAndSelectableSubmitCallbacks backButton,
            IInfiniteFuelOnOffButtonPressedUseCase infiniteFuelOnOffButtonPressedUseCase,
            IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase,
            IAudioOnOffButtonPressedUseCase audioOnOffButtonPressedUseCase,
            IBackButtonPressedUseCase backButtonPressedUseCase
            )
        {
            this.infiniteFuelOnOffButton = infiniteFuelOnOffButton;
            this.toggleFullscreenButton = toggleFullscreenButton;
            this.audioOnOffButton = audioOnOffButton;
            this.backButton = backButton;
            this.infiniteFuelOnOffButtonPressedUseCase = infiniteFuelOnOffButtonPressedUseCase;
            this.toggleFullscreenButtonPressedUseCase = toggleFullscreenButtonPressedUseCase;
            this.audioOnOffButtonPressedUseCase = audioOnOffButtonPressedUseCase;
            this.backButtonPressedUseCase = backButtonPressedUseCase;
        }

        public void Execute()
        {
            infiniteFuelOnOffButton.OnSubmit += infiniteFuelOnOffButtonPressedUseCase.Execute;
            toggleFullscreenButton.OnSubmit += toggleFullscreenButtonPressedUseCase.Execute;
            audioOnOffButton.OnSubmit += audioOnOffButtonPressedUseCase.Execute;
            backButton.OnSubmit += backButtonPressedUseCase.Execute;
        }
    }
}
