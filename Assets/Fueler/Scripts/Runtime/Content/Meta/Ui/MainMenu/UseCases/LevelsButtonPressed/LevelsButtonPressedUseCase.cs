using Fueler.Content.Meta.Ui.LevelSelection;
using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.LevelsButtonPressed
{
    public class LevelsButtonPressedUseCase : ILevelsButtonPressedUseCase
    {
        private readonly IUiViewStack uiViewStack;

        public LevelsButtonPressedUseCase(
            IUiViewStack uiViewStack
            )
        {
            this.uiViewStack = uiViewStack;
        }

        public void Execute()
        {
            uiViewStack.New().Show<ILevelSelectionUiInteractor>(instantly: false).HideAndPush<IMainMenuUiInteractor>(instantly: true).Execute();
        }
    }
}
