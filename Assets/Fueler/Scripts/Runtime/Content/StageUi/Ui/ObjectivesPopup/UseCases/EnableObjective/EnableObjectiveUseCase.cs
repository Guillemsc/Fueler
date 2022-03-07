using Fueler.Content.StageUi.Ui.ObjectivesPopup.Entries;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using System.Collections.Generic;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.EnableObjective
{
    public class EnableObjectiveUseCase : IEnableObjectiveUseCase
    {
        private readonly IReadOnlyList<ObjectiveEntry> objectivesEntries;

        public EnableObjectiveUseCase(
            IReadOnlyList<ObjectiveEntry> objectivesEntries
            )
        {
            this.objectivesEntries = objectivesEntries;
        }

        public void Execute(ObjectiveType objectiveType)
        {
            foreach(ObjectiveEntry objective in objectivesEntries)
            {
                bool isObjective = objective.ObjectiveType == objectiveType;

                objective.gameObject.SetActive(isObjective);
            }
        }
    }
}
