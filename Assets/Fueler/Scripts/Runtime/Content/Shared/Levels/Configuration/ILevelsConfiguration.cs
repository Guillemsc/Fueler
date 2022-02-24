using System.Collections.Generic;

namespace Fueler.Content.Shared.Levels.Configuration
{
    public interface ILevelsConfiguration
    {
        IReadOnlyList<ILevelConfiguration> Levels { get; }
    }
}
