using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Events;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.EnableObjective;
using System;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup
{
    public class ObjectivesPopupUiInteractor : IObjectivesPopupUiInteractor
    {
        private readonly ObjectivesPopupEvents objectivesPopupEvents;
        private readonly IEnableObjectiveUseCase enableObjectiveUseCase;

        public ObjectivesPopupUiInteractor(
            ObjectivesPopupEvents objectivesPopupEvents,
            IEnableObjectiveUseCase enableObjectiveUseCase
            )
        {
            this.objectivesPopupEvents = objectivesPopupEvents;
            this.enableObjectiveUseCase = enableObjectiveUseCase;
        }

        public void EnableObjective(ObjectiveType objectiveType)
        {
            enableObjectiveUseCase.Execute(objectiveType);
        }

        public void SubscribeOnClosed(Action onClosed)
        {
            objectivesPopupEvents.OnClosed += onClosed;
        }
    }
}
