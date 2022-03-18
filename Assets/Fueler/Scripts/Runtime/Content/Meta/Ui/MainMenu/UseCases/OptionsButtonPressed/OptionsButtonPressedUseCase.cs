using Fueler.Content.Meta.Ui.Options;
using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.OptionsButtonPressed
{
    public class OptionsButtonPressedUseCase : IOptionsButtonPressedUseCase
    {
        private readonly IUiViewStack uiViewStack;

        public OptionsButtonPressedUseCase(
            IUiViewStack uiViewStack
            )
        {
            this.uiViewStack = uiViewStack;
        }

        public void Execute()
        {
            uiViewStack.New()
                .SetInteractable<IMainMenuUiInteractor>(false)
                .Show<IOptionsUiInteractor>(instantly: false)
                .HideAndPush<IMainMenuUiInteractor>(instantly: true)
                .Execute();
        }
    }
}
