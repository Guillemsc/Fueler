using Fueler.Content.Stage.Level.Entities;

namespace Fueler.Content.Stage.Configuration
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
