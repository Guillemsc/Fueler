using Fueler.Content.Shared.Levels.Configuration;
using System;

namespace Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId
{
    public class TryGetLevelIndexByLevelIdUseCase : ITryGetLevelIndexByLevelIdUseCase
    {
        private readonly ILevelsConfiguration levelsConfiguration;

        public TryGetLevelIndexByLevelIdUseCase(
            ILevelsConfiguration levelsConfiguration
            )
        {
            this.levelsConfiguration = levelsConfiguration;
        }

        public bool Execute(Guid levelId, out int index)
        {
            for(int i = 0; i < levelsConfiguration.Levels.Count; ++i)
            {
                ILevelConfiguration level = levelsConfiguration.Levels[i];

                bool idEquals = level.Id == levelId;

                if(idEquals)
                {
                    index = i;
                    return true;
                }
            }

            index = default;
            return false;
        }
    }
}
