using Fueler.Content.StageUi.Ui.LevelFailed;
using Fueler.Content.StageUi.Ui.LevelCompleted;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstance : MonoBehaviour
    {
        [SerializeField] private LevelUiInstaller levelUiInstaller = default;
        [SerializeField] private LevelCompletedUiInstaller levelCompletedUiInstaller = default;
        [SerializeField] private LevelFailedUiInstaller levelFailedUiInstaller = default;

        public LevelUiInstaller LevelUiInstaller => levelUiInstaller;
        public LevelCompletedUiInstaller LevelCompletedUiInstaller => levelCompletedUiInstaller;
        public LevelFailedUiInstaller LevelFailedUiInstaller => levelFailedUiInstaller;
    }
}
