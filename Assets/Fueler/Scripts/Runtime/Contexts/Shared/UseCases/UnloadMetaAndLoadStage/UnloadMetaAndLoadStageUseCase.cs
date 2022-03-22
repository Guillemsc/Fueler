using Fueler.Content.Services.MetaAudio;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Meta;
using Fueler.Contexts.Shared.UseCases.LoadStage;
using Fueler.Contexts.Stage;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage
{
    public class UnloadMetaAndLoadStageUseCase : IUnloadMetaAndLoadStageUseCase
    {
        private readonly ILoadStageUseCase loadStageUseCase;

        public UnloadMetaAndLoadStageUseCase(
            ILoadStageUseCase loadStageUseCase
            )
        {
            this.loadStageUseCase = loadStageUseCase;
        }

        public async Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            await TryUnloadMeta();

            IStageContextInteractor stageInteractor = await loadStageUseCase.Execute(levelConfiguration, cancellationToken);

            await loadingToken.Complete();

            stageInteractor.Start();
        }

        private Task TryUnloadMeta()
        {
            bool metaFound = ServiceLocator.TryGet(
                out ITaskDisposable<IMetaContextInteractor> meta
                );

            if(!metaFound)
            {
                return Task.CompletedTask;
            }

            IMetaAudioService metaAudioService = ServiceLocator.Get<IMetaAudioService>();

            return Task.WhenAll(
                metaAudioService.Stop(CancellationToken.None),
                meta.Dispose()
                );
        }
    }
}
