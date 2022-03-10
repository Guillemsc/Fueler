using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.IsLevelCompleted;
using System;

namespace Fueler.Content.Shared.Levels.UseCases.TryGetLastUncompletedLevel
{
    public class TryGetLastUncompletedLevelUseCase : ITryGetLastUncompletedLevelUseCase
    {
        private readonly ILevelsConfiguration levelsConfiguration;
        private readonly IIsLevelCompletedUseCase isLevelCompletedUseCase;

        public TryGetLastUncompletedLevelUseCase(
            ILevelsConfiguration levelsConfiguration,
            IIsLevelCompletedUseCase isLevelCompletedUseCase
            )
        {
            this.levelsConfiguration = levelsConfiguration;
            this.isLevelCompletedUseCase = isLevelCompletedUseCase;
        }

        public bool Execute(out Guid levelUid)
        {
            foreach(ILevelConfiguration levelConfiguration in levelsConfiguration.Levels)
            {
                bool isCompleted = isLevelCompletedUseCase.Execute(levelConfiguration.Id);

                if(isCompleted)
                {
                    continue;
                }

                levelUid = levelConfiguration.Id;
                return true;
            }

            levelUid = default;
            return false;
        }
    }
}
