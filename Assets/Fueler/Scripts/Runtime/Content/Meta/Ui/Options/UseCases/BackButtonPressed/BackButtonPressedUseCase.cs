using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.Meta.Ui.Options.UseCases.BackButtonPressed
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
            uiViewStack.New()
                .ShowLastBehindForeground(instantly: true)
                .Hide<IOptionsUiInteractor>(instantly: false)
                .MoveCurrentToForeground()
                .Execute();
        }
    }
}
