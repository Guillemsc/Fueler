using Fueler.Content.Meta.Ui.LevelFailed.UseCases.TryAgainButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.LevelFailed.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks tryAgainButton;
        private readonly ITryAgainButtonPressedUseCase tryAgainButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks tryAgainButton,
            ITryAgainButtonPressedUseCase tryAgainButtonPressedUseCase
            )
        {
            this.tryAgainButton = tryAgainButton;
            this.tryAgainButtonPressedUseCase = tryAgainButtonPressedUseCase;
        }

        public void Execute()
        {
            tryAgainButton.OnSubmit += tryAgainButtonPressedUseCase.Execute;
        }
    }
}
