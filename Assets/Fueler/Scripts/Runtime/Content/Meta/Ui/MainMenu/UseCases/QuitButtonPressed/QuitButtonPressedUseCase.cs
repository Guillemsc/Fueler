using Juce.CoreUnity;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.QuitButtonPressed
{
    public class QuitButtonPressedUseCase : IQuitButtonPressedUseCase
    {
        public void Execute()
        {
            JuceAppliaction.Quit();
        }
    }
}
