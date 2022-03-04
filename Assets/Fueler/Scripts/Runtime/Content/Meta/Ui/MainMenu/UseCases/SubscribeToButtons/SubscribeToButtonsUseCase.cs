using Fueler.Content.Meta.Ui.MainMenu.UseCases.OptionsButtonPressed;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.PlayButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks playButton;
        private readonly PointerAndSelectableSubmitCallbacks optionsButton;
        private readonly IPlayButtonPressedUseCase playButtonPressedUseCase;
        private readonly IOptionsButtonPressedUseCase optionsButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks playButton,
            PointerAndSelectableSubmitCallbacks optionsButton,
            IPlayButtonPressedUseCase playButtonPressedUseCase,
            IOptionsButtonPressedUseCase optionsButtonPressedUseCase
            )
        {
            this.playButton = playButton;
            this.optionsButton = optionsButton;
            this.playButtonPressedUseCase = playButtonPressedUseCase;
            this.optionsButtonPressedUseCase = optionsButtonPressedUseCase;
        }

        public void Execute()
        {
            playButton.OnSubmit += playButtonPressedUseCase.Execute;
            optionsButton.OnSubmit += optionsButtonPressedUseCase.Execute;
        }
    }
}
