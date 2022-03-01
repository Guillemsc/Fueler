using Fueler.Content.Stage.General.Entities;
using System;

namespace Fueler.Content.Shared.Levels.Configuration
{
    public interface ILevelConfiguration
    {
        Guid Id { get; }
        LevelEntity LevelEntityPrefab { get; }
        int InitialFuel { get; }
    }
}
