using Fueler.Content.Meta.Ui.LevelSelection.UseCases.BackButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks backButton;
        private readonly IBackButtonPressedUseCase backButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks backButton,
            IBackButtonPressedUseCase backButtonPressedUseCase
            )
        {
            this.backButton = backButton;
            this.backButtonPressedUseCase = backButtonPressedUseCase;
        }

        public void Execute()
        {
            backButton.OnSubmit += backButtonPressedUseCase.Execute;
        }
    }
}
