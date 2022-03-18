using Fueler.Content.StageUi.Ui.LevelFailed.UseCases.BackToMainMenuButtonPressed;
using Fueler.Content.StageUi.Ui.LevelFailed.UseCases.TryAgainButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.StageUi.Ui.LevelFailed.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks tryAgainButton;
        private readonly PointerAndSelectableSubmitCallbacks backToMainMenuButton;
        private readonly ITryAgainButtonPressedUseCase tryAgainButtonPressedUseCase;
        private readonly IBackToMainMenuButtonPressedUseCase backToMainMenuButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks tryAgainButton,
            PointerAndSelectableSubmitCallbacks backToMainMenuButton,
            ITryAgainButtonPressedUseCase tryAgainButtonPressedUseCase,
            IBackToMainMenuButtonPressedUseCase backToMainMenuButtonPressedUseCase
            )
        {
            this.tryAgainButton = tryAgainButton;
            this.backToMainMenuButton = backToMainMenuButton;
            this.tryAgainButtonPressedUseCase = tryAgainButtonPressedUseCase;
            this.backToMainMenuButtonPressedUseCase = backToMainMenuButtonPressedUseCase;
        }

        public void Execute()
        {
            tryAgainButton.OnSubmit += tryAgainButtonPressedUseCase.Execute;
            backToMainMenuButton.OnSubmit += backToMainMenuButtonPressedUseCase.Execute;
        }
    }
}
