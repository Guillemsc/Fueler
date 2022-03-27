using Fueler.Content.Meta.Ui.Accessibility.UseCases.BackButtonPressed;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.ToggleInfiniteFuelButtonPressed;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.ToggleInfiniteTimeButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.Accessibility.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks toggleInfiniteFuelButton;
        private readonly PointerAndSelectableSubmitCallbacks toggleInfiniteTimeButton;
        private readonly PointerAndSelectableSubmitCallbacks backButton;
        private readonly IToggleInfiniteFuelButtonPressedUseCase toggleInfiniteFuelButtonPressedUseCase;
        private readonly IToggleInfiniteTimeButtonPressedUseCase toggleInfiniteTimeButtonPressedUseCase;
        private readonly IBackButtonPressedUseCase backButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks toggleInfiniteFuelButton,
            PointerAndSelectableSubmitCallbacks toggleInfiniteTimeButton,
            PointerAndSelectableSubmitCallbacks backButton,
            IToggleInfiniteFuelButtonPressedUseCase toggleInfiniteFuelButtonPressedUseCase,
            IToggleInfiniteTimeButtonPressedUseCase toggleInfiniteTimeButtonPressedUseCase,
            IBackButtonPressedUseCase backButtonPressedUseCase
            )
        {
            this.toggleInfiniteFuelButton = toggleInfiniteFuelButton;
            this.toggleInfiniteTimeButton = toggleInfiniteTimeButton;
            this.backButton = backButton;
            this.toggleInfiniteFuelButtonPressedUseCase = toggleInfiniteFuelButtonPressedUseCase;
            this.toggleInfiniteTimeButtonPressedUseCase = toggleInfiniteTimeButtonPressedUseCase;
            this.backButtonPressedUseCase = backButtonPressedUseCase;
        }

        public void Execute()
        {
            toggleInfiniteFuelButton.OnSubmit += toggleInfiniteFuelButtonPressedUseCase.Execute;
            toggleInfiniteTimeButton.OnSubmit += toggleInfiniteTimeButtonPressedUseCase.Execute;
            backButton.OnSubmit += backButtonPressedUseCase.Execute;
        }
    }
}
