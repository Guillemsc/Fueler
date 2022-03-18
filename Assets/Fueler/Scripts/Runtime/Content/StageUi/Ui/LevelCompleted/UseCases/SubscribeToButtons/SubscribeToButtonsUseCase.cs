using Fueler.Content.StageUi.Ui.LevelCompleted.UseCases.BackToMainMenuButtonPressed;
using Fueler.Content.StageUi.Ui.LevelCompleted.UseCases.ContinueButtonPressed;
using Fueler.Content.StageUi.Ui.LevelCompleted.UseCases.TryAgainButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.StageUi.Ui.LevelCompleted.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks continueButton;
        private readonly PointerAndSelectableSubmitCallbacks tryAgainButton;
        private readonly PointerAndSelectableSubmitCallbacks backToMainMenuButton;
        private readonly IContinueButtonPressedUseCase continueButtonPressedUseCase;
        private readonly ITryAgainButtonPressedUseCase tryAgainButtonPressedUseCase;
        private readonly IBackToMainMenuButtonPressedUseCase backToMainMenuButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks continueButton,
            PointerAndSelectableSubmitCallbacks tryAgainButton,
            PointerAndSelectableSubmitCallbacks backToMainMenuButton,
            IContinueButtonPressedUseCase continueButtonPressedUseCase,
            ITryAgainButtonPressedUseCase tryAgainButtonPressedUseCase,
            IBackToMainMenuButtonPressedUseCase backToMainMenuButtonPressedUseCase
            )
        {
            this.continueButton = continueButton;
            this.tryAgainButton = tryAgainButton;
            this.backToMainMenuButton = backToMainMenuButton;
            this.continueButtonPressedUseCase = continueButtonPressedUseCase;
            this.tryAgainButtonPressedUseCase = tryAgainButtonPressedUseCase;
            this.backToMainMenuButtonPressedUseCase = backToMainMenuButtonPressedUseCase;
        }

        public void Execute()
        {
            continueButton.OnSubmit += continueButtonPressedUseCase.Execute;
            tryAgainButton.OnSubmit += tryAgainButtonPressedUseCase.Execute;
            backToMainMenuButton.OnSubmit += backToMainMenuButtonPressedUseCase.Execute;
        }
    }
}
