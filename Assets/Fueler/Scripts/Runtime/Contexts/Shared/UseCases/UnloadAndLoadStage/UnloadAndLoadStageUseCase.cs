using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Shared.UseCases.LoadStage;
using Fueler.Contexts.Shared.UseCases.UnloadStage;
using Fueler.Contexts.Stage;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage
{
    public class UnloadAndLoadStageUseCase : IUnloadAndLoadStageUseCase
    {
        private readonly ILoadStageUseCase loadStageUseCase;
        private readonly IUnloadStageUseCase unloadStageUseCase;

        public UnloadAndLoadStageUseCase(
            ILoadStageUseCase loadStageUseCase,
            IUnloadStageUseCase unloadStageUseCase
            )
        {
            this.loadStageUseCase = loadStageUseCase;
            this.unloadStageUseCase = unloadStageUseCase;
        }

        public async Task Execute(
            ILevelConfiguration levelConfiguration,
            bool isReload,
            CancellationToken cancellationToken
            )
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            await unloadStageUseCase.Execute(isReload, cancellationToken);

            IStageContextInteractor stageInteractor = await loadStageUseCase.Execute(levelConfiguration, cancellationToken);

            await loadingToken.Complete();

            stageInteractor.Start();
        }
    }
}
