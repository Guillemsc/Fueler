using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SetEntryAsFirstSelected;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.TrySpawnLevelEntry;
using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.TryGetLastUncompletedLevel;
using System;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntries
{
    public class SpawnLevelEntriesUseCase : ISpawnLevelEntriesUseCase
    {
        private readonly ILevelsConfiguration levelsConfiguration;
        private readonly ITrySpawnLevelEntryUseCase trySpawnLevelEntryUseCase;
        private readonly ISetEntryAsFirstSelectedUseCase setEntryAsFirstSelectedUseCase;
        private readonly ITryGetLastUncompletedLevelUseCase tryGetLastUncompletedLevelUseCase;

        public SpawnLevelEntriesUseCase(
            ILevelsConfiguration levelsConfiguration,
            ITrySpawnLevelEntryUseCase trySpawnLevelEntryUseCase,
            ISetEntryAsFirstSelectedUseCase setEntryAsFirstSelectedUseCase,
            ITryGetLastUncompletedLevelUseCase tryGetLastUncompletedLevelUseCase
            )
        {
            this.levelsConfiguration = levelsConfiguration;
            this.trySpawnLevelEntryUseCase = trySpawnLevelEntryUseCase;
            this.setEntryAsFirstSelectedUseCase = setEntryAsFirstSelectedUseCase;
            this.tryGetLastUncompletedLevelUseCase = tryGetLastUncompletedLevelUseCase;
        }

        public void Execute()
        {
            bool lastUncompletedLevelFound = tryGetLastUncompletedLevelUseCase.Execute(
                out Guid lastUncompletedLevelUid
                );

            bool locked = false;

            for (int i = 0; i < levelsConfiguration.Levels.Count; ++i)
            {
                ILevelConfiguration levelConfiguration = levelsConfiguration.Levels[i];

                bool spawned = trySpawnLevelEntryUseCase.Execute(
                    i + 1,
                    locked,
                    levelConfiguration,
                    out LevelTextButtonWidget levelEntry
                    );

                if(i == 0)
                {
                    setEntryAsFirstSelectedUseCase.Execute(levelEntry);
                }

                if (!lastUncompletedLevelFound)
                {
                    continue;
                }

                if(levelConfiguration.Id == lastUncompletedLevelUid)
                {
                    locked = true;
                }
            }
        }
    }
}
