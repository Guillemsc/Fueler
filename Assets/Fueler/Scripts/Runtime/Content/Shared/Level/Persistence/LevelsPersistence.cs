using System;
using System.Collections.Generic;
using System.Text;

namespace Fueler.Content.Stage.Accessibility.Persistence
{
    [System.Serializable]
    public class LevelsPersistence
    {
        public static readonly string Path = "Levels";

        public Guid LastPlayedLevel { get; set; } = Guid.Empty;
        public bool LastPlayedLevelCompleted { get; set; } = false;
        public List<Guid> CompletedLevels { get; set; } = new List<Guid>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("({0}-{1})", nameof(LastPlayedLevel), LastPlayedLevel));
            stringBuilder.AppendLine(string.Format("({0}-{1})", nameof(LastPlayedLevelCompleted), LastPlayedLevelCompleted));

            stringBuilder.AppendLine(string.Format("{0}:", nameof(CompletedLevels)));
            foreach (Guid completedLevel in CompletedLevels)
            {
                stringBuilder.AppendLine(string.Format("- {0}", completedLevel));
            }

            return stringBuilder.ToString();
        }
    }
}
