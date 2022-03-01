using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using System.Threading;

namespace Fueler.Content.Shared.Levels.UseCases.LoadNextLevel
{
    public class LoadNextLevelUseCase : ILoadNextLevelUseCase
    {
        private readonly ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase;
        private readonly ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase;
        private readonly IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase;

        public LoadNextLevelUseCase(
            ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase,
            ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase,
            IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase
            )
        {
            this.tryGetLevelIndexByLevelIdUseCase = tryGetLevelIndexByLevelIdUseCase;
            this.tryGetLevelByIndexUseCase = tryGetLevelByIndexUseCase;
            this.unloadAndLoadStageUseCase = unloadAndLoadStageUseCase;
        }

        public async void Execute()
        {
            //bool levelIndexFound = tryGetLevelIndexByLevelIdUseCase.Execute(default, out int levelIndex);

            //if(!levelIndexFound)
            //{
            //    return;
            //}

            //int nextLevelIndex = levelIndex + 1;

            // Debug
            int nextLevelIndex = 0;

            bool nextLevelFound = tryGetLevelByIndexUseCase.Execute(
                nextLevelIndex,
                out ILevelConfiguration nextLevelConfiguration
                );

            if(!nextLevelFound)
            {
                return;
            }

            unloadAndLoadStageUseCase.Execute(nextLevelConfiguration, CancellationToken.None).RunAsync();
        }
    }
}
