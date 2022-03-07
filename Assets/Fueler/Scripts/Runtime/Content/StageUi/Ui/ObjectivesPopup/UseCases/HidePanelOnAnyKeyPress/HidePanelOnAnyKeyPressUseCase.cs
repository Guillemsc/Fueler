using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.HidePanelOnAnyKeyPress
{
    public class HidePanelOnAnyKeyPressUseCase : IHidePanelOnAnyKeyPressUseCase
    {
        private readonly IUiViewStack uiViewStack;

        public HidePanelOnAnyKeyPressUseCase(
            IUiViewStack uiViewStack
            )
        {
            this.uiViewStack = uiViewStack;
        }

        public void Execute()
        {
            uiViewStack.New().Hide<IObjectivesPopupUiInteractor>(instantly: false).Execute();
        }
    }
}
