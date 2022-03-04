using Fueler.Content.Meta.Ui.MainMenu.UseCases.OptionsButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks optionsButton;
        private readonly IOptionsButtonPressedUseCase optionsButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks optionsButton,
            IOptionsButtonPressedUseCase optionsButtonPressedUseCase
            )
        {
            this.optionsButton = optionsButton;
            this.optionsButtonPressedUseCase = optionsButtonPressedUseCase;
        }

        public void Execute()
        {
            optionsButton.OnSubmit += optionsButtonPressedUseCase.Execute;
        }
    }
}
