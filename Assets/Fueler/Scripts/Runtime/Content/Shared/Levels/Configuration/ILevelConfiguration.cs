using Fueler.Content.Stage.Level.Entities;
using System;

namespace Fueler.Content.Shared.Levels.Configuration
{
    public interface ILevelConfiguration
    {
        Guid Id { get; }
        LevelEntity LevelEntityPrefab { get; }
    }
}
