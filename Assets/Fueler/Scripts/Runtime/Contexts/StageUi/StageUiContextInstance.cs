using Fueler.Content.StageUi.Ui.EndStage;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstance : MonoBehaviour
    {
        [SerializeField] private LevelUiInstaller levelUiInstaller = default;
        [SerializeField] private EndStageUiInstaller endStageUiInstaller = default;

        public LevelUiInstaller LevelUiInstaller => levelUiInstaller;
        public EndStageUiInstaller EndStageUiInstaller => endStageUiInstaller;
    }
}
