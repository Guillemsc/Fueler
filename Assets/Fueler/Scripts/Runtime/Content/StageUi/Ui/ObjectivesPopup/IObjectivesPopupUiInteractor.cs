using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using System;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup
{
    public interface IObjectivesPopupUiInteractor
    {
        void EnableObjective(ObjectiveType objectiveType);
        void SubscribeOnClosed(Action onClose);
    }
}
