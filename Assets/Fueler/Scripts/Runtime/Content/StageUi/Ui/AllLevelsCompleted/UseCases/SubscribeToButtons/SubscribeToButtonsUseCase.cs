using Fueler.Content.StageUi.Ui.AllLevelsCompleted.UseCases.ContinueButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.StageUi.Ui.AllLevelsCompleted.UseCase.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks continueButton;
        private readonly IContinueButtonPressedUseCase continueButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks continueButton,
            IContinueButtonPressedUseCase continueButtonPressedUseCase
            )
        {
            this.continueButton = continueButton;
            this.continueButtonPressedUseCase = continueButtonPressedUseCase;
        }

        public void Execute()
        {
            continueButton.OnSubmit += continueButtonPressedUseCase.Execute;
        }
    }
}
