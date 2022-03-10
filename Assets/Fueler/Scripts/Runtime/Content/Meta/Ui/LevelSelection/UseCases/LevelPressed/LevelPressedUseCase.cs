using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage;
using System.Threading;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.LevelPressed
{
    public class LevelPressedUseCase : ILevelPressedUseCase
    {
        private readonly IUnloadMetaAndLoadStageUseCase unloadMetaAndLoadStageUseCase;

        public LevelPressedUseCase(
            IUnloadMetaAndLoadStageUseCase unloadMetaAndLoadStageUseCase
            )
        {
            this.unloadMetaAndLoadStageUseCase = unloadMetaAndLoadStageUseCase;
        }

        public void Execute(ILevelConfiguration levelConfiguration)
        {
            unloadMetaAndLoadStageUseCase.Execute(levelConfiguration, CancellationToken.None).RunAsync();
        }
    }
}
