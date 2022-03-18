using Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta;
using System.Threading;

namespace Fueler.Content.StageUi.Ui.AllLevelsCompleted.UseCases.ContinueButtonPressed
{
    public class ContinueButtonPressedUseCase : IContinueButtonPressedUseCase
    {
        private readonly IUnloadStageAndLoadMetaUseCase unloadStageAndLoadMetaUseCase;

        public ContinueButtonPressedUseCase(
            IUnloadStageAndLoadMetaUseCase unloadStageAndLoadMetaUseCase
            )
        {
            this.unloadStageAndLoadMetaUseCase = unloadStageAndLoadMetaUseCase;
        }

        public void Execute()
        {
            unloadStageAndLoadMetaUseCase.Execute(CancellationToken.None).RunAsync();
        }
    }
}
