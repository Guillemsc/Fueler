using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntry;
using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntries
{
    public class SpawnLevelEntriesUseCase : ISpawnLevelEntriesUseCase
    {
        private readonly ILevelsConfiguration levelsConfiguration;
        private readonly ISpawnLevelEntryUseCase spawnLevelEntryUseCase;

        public SpawnLevelEntriesUseCase(
            ILevelsConfiguration levelsConfiguration,
            ISpawnLevelEntryUseCase spawnLevelEntryUseCase
            )
        {
            this.levelsConfiguration = levelsConfiguration;
            this.spawnLevelEntryUseCase = spawnLevelEntryUseCase;
        }

        public void Execute()
        {
            for(int i = 0; i < levelsConfiguration.Levels.Count; ++i)
            {
                ILevelConfiguration levelConfiguration = levelsConfiguration.Levels[i];

                spawnLevelEntryUseCase.Execute(i + 1, levelConfiguration);
            }
        }
    }
}
