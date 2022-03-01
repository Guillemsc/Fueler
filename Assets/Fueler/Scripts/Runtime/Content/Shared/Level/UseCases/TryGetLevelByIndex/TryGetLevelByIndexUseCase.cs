using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex
{
    public class TryGetLevelByIndexUseCase : ITryGetLevelByIndexUseCase
    {
        private readonly ILevelsConfiguration levelsConfiguration;

        public TryGetLevelByIndexUseCase(
            ILevelsConfiguration levelsConfiguration
            )
        {
            this.levelsConfiguration = levelsConfiguration;
        }

        public bool Execute(int levelIndex, out ILevelConfiguration levelConfiguration)
        {
            if(levelsConfiguration.Levels.Count <= levelIndex)
            {
                levelConfiguration = default;
                return false;
            }

            levelConfiguration = levelsConfiguration.Levels[levelIndex];
            return true;
        }
    }
}
