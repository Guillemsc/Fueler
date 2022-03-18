using Fueler.Content.Shared.Levels.Configuration;
using System;

namespace Fueler.Content.Shared.Levels.UseCases.IsLastLevel
{
    public class IsLastLevelUseCase : IIsLastLevelUseCase
    {
        private readonly ILevelsConfiguration levelsConfiguration;

        public IsLastLevelUseCase(
            ILevelsConfiguration levelsConfiguration
            )
        {
            this.levelsConfiguration = levelsConfiguration;
        }

        public bool Execute(Guid levelId)
        {
            for (int i = 0; i < levelsConfiguration.Levels.Count; ++i)
            {
                ILevelConfiguration level = levelsConfiguration.Levels[i];

                bool idEquals = level.Id == levelId;

                if (!idEquals)
                {
                    continue;
                }

                bool isLast = i == levelsConfiguration.Levels.Count - 1;

                return isLast;
            }

            return false;
        }
    }
}
