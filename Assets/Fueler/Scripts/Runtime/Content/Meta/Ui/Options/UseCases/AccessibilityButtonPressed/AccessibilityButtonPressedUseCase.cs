using Fueler.Content.Meta.Ui.Accessibility;
using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.Meta.Ui.Options.UseCases.AccessibilityButtonPressed
{
    public class AccessibilityButtonPressedUseCase : IAccessibilityButtonPressedUseCase
    {
        private readonly IUiViewStack uiViewStack;

        public AccessibilityButtonPressedUseCase(
            IUiViewStack uiViewStack
            )
        {
            this.uiViewStack = uiViewStack;
        }

        public void Execute()
        {
            uiViewStack.New()
                .SetInteractable<IOptionsUiInteractor>(false)
                .Show<IAccessibilityUiInteractor>(instantly: false)
                .HideAndPush<IOptionsUiInteractor>(instantly: true)
                .Execute();
        }
    }
}
