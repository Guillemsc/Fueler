using Fueler.Content.StageUi.Ui.LevelFailed;
using Fueler.Content.StageUi.Ui.LevelCompleted;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;
using Fueler.Content.StageUi.Ui.ObjectivesPopup;
using Fueler.Content.StageUi.Ui.AllLevelsCompleted;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstance : MonoBehaviour
    {
        [SerializeField] private LevelUiInstaller levelUiInstaller = default;
        [SerializeField] private LevelCompletedUiInstaller levelCompletedUiInstaller = default;
        [SerializeField] private LevelFailedUiInstaller levelFailedUiInstaller = default;
        [SerializeField] private AllLevelsCompletedUiInstaller allLevelsCompletedUiInstaller = default;
        [SerializeField] private ObjectivesPopupUiInstaller objectivesPopupUiInstaller = default;

        public LevelUiInstaller LevelUiInstaller => levelUiInstaller;
        public LevelCompletedUiInstaller LevelCompletedUiInstaller => levelCompletedUiInstaller;
        public LevelFailedUiInstaller LevelFailedUiInstaller => levelFailedUiInstaller;
        public AllLevelsCompletedUiInstaller AllLevelsCompletedUiInstaller => allLevelsCompletedUiInstaller;
        public ObjectivesPopupUiInstaller ObjectivesPopupUiInstaller => objectivesPopupUiInstaller;
    }
}
