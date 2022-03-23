using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using System.Threading;

namespace Fueler.Content.Shared.Levels.UseCases.ReloadLevel
{
    public class ReloadLevelUseCase : IReloadLevelUseCase
    {
        private readonly ILevelConfiguration levelConfiguration;
        private readonly IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase;

        public ReloadLevelUseCase(
            ILevelConfiguration levelConfiguration,
            IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase
            )
        {
            this.levelConfiguration = levelConfiguration;
            this.unloadAndLoadStageUseCase = unloadAndLoadStageUseCase;
        }

        public void Execute()
        {
            unloadAndLoadStageUseCase.Execute(
                levelConfiguration,
                isReload: true,
                CancellationToken.None
                ).RunAsync();
        }
    }
}
