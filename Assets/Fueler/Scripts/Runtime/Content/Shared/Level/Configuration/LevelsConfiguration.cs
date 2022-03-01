using System.Collections.Generic;

namespace Fueler.Content.Shared.Levels.Configuration
{
    public class LevelsConfiguration : ILevelsConfiguration
    {
        public IReadOnlyList<ILevelConfiguration> Levels { get; }

        public LevelsConfiguration(IReadOnlyList<ILevelConfiguration> levels)
        {
            Levels = levels;
        }
    }
}
