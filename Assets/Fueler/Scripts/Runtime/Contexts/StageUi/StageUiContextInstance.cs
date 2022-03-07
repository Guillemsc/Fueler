using Fueler.Content.StageUi.Ui.LevelFailed;
using Fueler.Content.StageUi.Ui.LevelCompleted;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;
using Fueler.Content.StageUi.Ui.ObjectivesPopup;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstance : MonoBehaviour
    {
        [SerializeField] private LevelUiInstaller levelUiInstaller = default;
        [SerializeField] private LevelCompletedUiInstaller levelCompletedUiInstaller = default;
        [SerializeField] private LevelFailedUiInstaller levelFailedUiInstaller = default;
        [SerializeField] private ObjectivesPopupUiInstaller objectivesPopupUiInstaller = default;

        public LevelUiInstaller LevelUiInstaller => levelUiInstaller;
        public LevelCompletedUiInstaller LevelCompletedUiInstaller => levelCompletedUiInstaller;
        public LevelFailedUiInstaller LevelFailedUiInstaller => levelFailedUiInstaller;
        public ObjectivesPopupUiInstaller ObjectivesPopupUiInstaller => objectivesPopupUiInstaller;
    }
}
