using Fueler.Content.Services.StageAudio;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.Core.Disposables;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadStage
{
    public class UnloadStageUseCase : IUnloadStageUseCase
    {
        public Task Execute(CancellationToken cancellationToken)
        {
            IStageAudioService stageAudioService = ServiceLocator.Get<IStageAudioService>();

            return Task.WhenAll(
                UnloadContexts(),
                stageAudioService.Stop(cancellationToken)
                );
        }

        private async Task UnloadContexts()
        {
            bool stageFound = ServiceLocator.TryGet(
                out ITaskDisposable<IStageContextInteractor> stage
                );

            bool stageUiFound = ServiceLocator.TryGet(
                out ITaskDisposable<IStageUiContextInteractor> stageUi
                );

            if (stageFound)
            {
                await stage.Dispose();
            }

            if (stageUiFound)
            {
                await stageUi.Dispose();
            }
        }
    }
}
