using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using System.Collections.Generic;
using System.Text;

namespace Fueler.Content.Stage.Tutorial.Persistence
{
    [System.Serializable]
    public class TutorialPersistence
    {
        public static readonly string Path = "Tutorial";

        public List<ObjectiveType> ObjectivesPanelsSeen { get; } = new List<ObjectiveType>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("{0}:", nameof(ObjectivesPanelsSeen)));
            foreach (ObjectiveType objectiveSeen in ObjectivesPanelsSeen)
            {
                stringBuilder.AppendLine(string.Format("- {0}:", objectiveSeen));
            }

            return stringBuilder.ToString();
        }
    }
}
