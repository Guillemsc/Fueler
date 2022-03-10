using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.BackButtonPressed
{
    public class BackButtonPressedUseCase : IBackButtonPressedUseCase
    {
        private readonly IUiViewStack uiViewStack;

        public BackButtonPressedUseCase(
            IUiViewStack uiViewStack
            )
        {
            this.uiViewStack = uiViewStack;
        }

        public void Execute()
        {
            uiViewStack.New().ShowLastBehindForeground(instantly: true).Hide<ILevelSelectionUiInteractor>(instantly: false).Execute();
        }
    }
}
