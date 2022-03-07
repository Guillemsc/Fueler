using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using UnityEngine;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup.Entries
{
    public class ObjectiveEntry : MonoBehaviour
    {
        [SerializeField] private ObjectiveType objectiveType = default;

        public ObjectiveType ObjectiveType => objectiveType;
    }
}
