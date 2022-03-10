using System;
using System.Collections.Generic;
using System.Text;

namespace Fueler.Content.Stage.Accessibility.Persistence
{
    [System.Serializable]
    public class LevelsPersistence
    {
        public static readonly string Path = "Levels";

        public List<Guid> CompletedLevels { get; set; } = new List<Guid>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("{0}:", nameof(CompletedLevels)));
            foreach (Guid completedLevel in CompletedLevels)
            {
                stringBuilder.AppendLine(string.Format("- {0}", completedLevel));
            }

            return stringBuilder.ToString();
        }
    }
}
