using Fueler.Content.Stage.Level.Entities;

namespace Fueler.Content.General.Configuration.Levels
{
    public class LevelConfiguration
    {
        public LevelEntity LevelEntityPrefab { get; }

        public LevelConfiguration(
            LevelEntity levelEntityPrefab
            )
        {
            LevelEntityPrefab = levelEntityPrefab;
        }
    }
}
