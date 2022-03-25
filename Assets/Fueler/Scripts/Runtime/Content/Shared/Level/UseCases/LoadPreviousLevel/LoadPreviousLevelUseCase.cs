using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using System.Threading;

namespace Fueler.Content.Shared.Levels.UseCases.LoadPreviousLevel
{
    public class LoadPreviousLevelUseCase : ILoadPreviousLevelUseCase
    {
        private readonly ILevelConfiguration levelConfiguration;
        private readonly ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase;
        private readonly ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase;
        private readonly IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase;

        public LoadPreviousLevelUseCase(
            ILevelConfiguration levelConfiguration,
            ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase,
            ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase,
            IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase
            )
        {
            this.levelConfiguration = levelConfiguration;
            this.tryGetLevelIndexByLevelIdUseCase = tryGetLevelIndexByLevelIdUseCase;
            this.tryGetLevelByIndexUseCase = tryGetLevelByIndexUseCase;
            this.unloadAndLoadStageUseCase = unloadAndLoadStageUseCase;
        }

        public void Execute()
        {
            bool levelIndexFound = tryGetLevelIndexByLevelIdUseCase.Execute(
                levelConfiguration.Id,
                out int levelIndex
                );

            if (!levelIndexFound)
            {
                UnityEngine.Debug.Log($"Could not find level index of level {levelConfiguration.Id}. Won't play next level.");
                return;
            }

            int nextLevelIndex = levelIndex - 1;

            bool nextLevelFound = tryGetLevelByIndexUseCase.Execute(
                nextLevelIndex,
                out ILevelConfiguration nextLevelConfiguration
                );

            if (!nextLevelFound)
            {
                bool fallbackLevelFound = tryGetLevelByIndexUseCase.Execute(
                    0,
                    out nextLevelConfiguration
                    );

                if (!fallbackLevelFound)
                {
                    return;
                }

                UnityEngine.Debug.Log($"Level with index {nextLevelIndex} not found. Loading fallback");
            }

            unloadAndLoadStageUseCase.Execute(nextLevelConfiguration, isReload: false, CancellationToken.None).RunAsync();
        }
    }
}
