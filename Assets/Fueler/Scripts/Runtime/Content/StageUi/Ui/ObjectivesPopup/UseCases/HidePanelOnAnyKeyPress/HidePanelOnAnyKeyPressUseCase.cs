using Fueler.Content.StageUi.Ui.ObjectivesPopup.Events;
using Juce.CoreUnity.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.HidePanelOnAnyKeyPress
{
    public class HidePanelOnAnyKeyPressUseCase : IHidePanelOnAnyKeyPressUseCase
    {
        private readonly IUiViewStack uiViewStack;
        private readonly ObjectivesPopupEvents objectivesPopupEvents;

        public HidePanelOnAnyKeyPressUseCase(
            IUiViewStack uiViewStack,
            ObjectivesPopupEvents objectivesPopupEvents
            )
        {
            this.uiViewStack = uiViewStack;
            this.objectivesPopupEvents = objectivesPopupEvents;
        }

        public void Execute()
        {
            Hide().RunAsync();
        }

        private async Task Hide()
        {
            await uiViewStack.New().Hide<IObjectivesPopupUiInteractor>(instantly: false).Execute(CancellationToken.None);

            objectivesPopupEvents.OnClosed?.Invoke();
            objectivesPopupEvents.OnClosed = null;
        }
    }
}
