using Fueler.Content.Meta.Ui.Options.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Options.UseCases.ToggleFullscreenButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.Options.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks toggleFullscreenButton;
        private readonly PointerAndSelectableSubmitCallbacks backButton;
        private readonly IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase;
        private readonly IBackButtonPressedUseCase backButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks toggleFullscreenButton,
            PointerAndSelectableSubmitCallbacks backButton,
            IToggleFullscreenButtonPressedUseCase toggleFullscreenButtonPressedUseCase,
            IBackButtonPressedUseCase backButtonPressedUseCase
            )
        {
            this.toggleFullscreenButton = toggleFullscreenButton;
            this.backButton = backButton;
            this.toggleFullscreenButtonPressedUseCase = toggleFullscreenButtonPressedUseCase;
            this.backButtonPressedUseCase = backButtonPressedUseCase;
        }

        public void Execute()
        {
            toggleFullscreenButton.OnSubmit += toggleFullscreenButtonPressedUseCase.Execute;
            backButton.OnSubmit += backButtonPressedUseCase.Execute;
        }
    }
}
