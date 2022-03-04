using Fueler.Content.Meta.Ui.MainMenu.UseCases.OptionsButtonPressed;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.PlayButtonPressed;
using Fueler.Content.Meta.Ui.MainMenu.UseCases.QuitButtonPressed;
using Juce.CoreUnity.Ui.Others;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerAndSelectableSubmitCallbacks playButton;
        private readonly PointerAndSelectableSubmitCallbacks optionsButton;
        private readonly PointerAndSelectableSubmitCallbacks quitButton;
        private readonly IPlayButtonPressedUseCase playButtonPressedUseCase;
        private readonly IOptionsButtonPressedUseCase optionsButtonPressedUseCase;
        private readonly IQuitButtonPressedUseCase quitButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerAndSelectableSubmitCallbacks playButton,
            PointerAndSelectableSubmitCallbacks optionsButton,
            PointerAndSelectableSubmitCallbacks quitButton,
            IPlayButtonPressedUseCase playButtonPressedUseCase,
            IOptionsButtonPressedUseCase optionsButtonPressedUseCase,
            IQuitButtonPressedUseCase quitButtonPressedUseCase
            )
        {
            this.playButton = playButton;
            this.optionsButton = optionsButton;
            this.quitButton = quitButton;
            this.playButtonPressedUseCase = playButtonPressedUseCase;
            this.optionsButtonPressedUseCase = optionsButtonPressedUseCase;
            this.quitButtonPressedUseCase = quitButtonPressedUseCase;
        }

        public void Execute()
        {
            playButton.OnSubmit += playButtonPressedUseCase.Execute;
            optionsButton.OnSubmit += optionsButtonPressedUseCase.Execute;
            quitButton.OnSubmit += quitButtonPressedUseCase.Execute;
        }
    }
}
