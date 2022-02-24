using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Shared;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Shared.Levels.UseCases.LoadNextLevel
{
    public class LoadNextLevelUseCase : ILoadNextLevelUseCase
    {
        private readonly ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase;
        private readonly ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase;

        public LoadNextLevelUseCase(
            ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase,
            ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase
            )
        {
            this.tryGetLevelIndexByLevelIdUseCase = tryGetLevelIndexByLevelIdUseCase;
            this.tryGetLevelByIndexUseCase = tryGetLevelByIndexUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
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

            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ILoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            await Unload(cancellationToken);

            await Load(nextLevelConfiguration, cancellationToken);

            loadingToken.Complete();
        }

        private async Task Unload(CancellationToken cancellationToken)
        {
            ITaskDisposable<IStageUiContextInteractor> stageUi = ServiceLocator.Get<ITaskDisposable<IStageUiContextInteractor>>();
            ITaskDisposable<IStageContextInteractor> stage = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

            await stage.Dispose();
            await stageUi.Dispose();
        }

        private async Task Load(ILevelConfiguration nextLevelConfiguration, CancellationToken cancellationToken)
        {
            IContextFactories contextFactories = ServiceLocator.Get<IContextFactories>();

            ITaskDisposable<IStageUiContextInteractor> stageUiInteractor = await contextFactories.StageUi.Create();
            ITaskDisposable<IStageContextInteractor> stageInteractor = await contextFactories.Stage.Create();

            await stageInteractor.Value.Load(nextLevelConfiguration, cancellationToken);
        }
    }
}
