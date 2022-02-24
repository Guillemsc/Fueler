using Fueler.Content.StageUi.Ui.EndStage;
using UnityEngine;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstance : MonoBehaviour
    {
        [SerializeField] private EndStageUiInstaller endStageUiInstaller = default;

        public EndStageUiInstaller EndStageUiInstaller => endStageUiInstaller;
    }
}
