using Fueler.Content.Stage.General.Entities;
using System;

namespace Fueler.Content.Shared.Levels.Configuration
{
    public class LevelConfiguration : ILevelConfiguration
    {
        public Guid Id { get; }
        public LevelEntity LevelEntityPrefab { get; }
        public int InitialFuel { get; }
        public int MaxTime { get; }

        public LevelConfiguration(
            Guid id,
            LevelEntity levelEntityPrefab,
            int initialFuel,
            int maxTime
            )
        {
            Id = id;
            LevelEntityPrefab = levelEntityPrefab;
            InitialFuel = initialFuel;
            MaxTime = maxTime;
        }
    }
}
