using Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta;
using System.Threading;

namespace Fueler.Content.Meta.Ui.LevelCompleted.UseCases.BackToMainMenuButtonPressed
{
    public class BackToMainMenuButtonPressedUseCase : IBackToMainMenuButtonPressedUseCase
    {
        private readonly IUnloadStageAndLoadMetaUseCase unloadStageAndLoadMetaUseCase;

        public BackToMainMenuButtonPressedUseCase(
            IUnloadStageAndLoadMetaUseCase unloadStageAndLoadMetaUseCase
            )
        {
            this.unloadStageAndLoadMetaUseCase = unloadStageAndLoadMetaUseCase;
        }

        public void Execute()
        {
            unloadStageAndLoadMetaUseCase.Execute(CancellationToken.None);
        }
    }
}
