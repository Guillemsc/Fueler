using System.Collections.Generic;

namespace Fueler.Content.General.Configuration.Levels
{
    public class LevelsConfiguration 
    {
        public IReadOnlyList<LevelConfiguration> Levels { get; }

        public LevelsConfiguration(IReadOnlyList<LevelConfiguration> levels)
        {
            Levels = levels;
        }
    }
}
