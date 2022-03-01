using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage
{
    public class UnloadAndLoadStageUseCase : IUnloadAndLoadStageUseCase
    {
        public async Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            await Unload(cancellationToken);

            await LoadAndStart(levelConfiguration, loadingToken, cancellationToken);
        }

        private async Task Unload(CancellationToken cancellationToken)
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

        private async Task LoadAndStart(
            ILevelConfiguration levelConfiguration,
            ITaskLoadingToken loadingToken, 
            CancellationToken cancellationToken
            )
        {
            IContextFactories contextFactories = ServiceLocator.Get<IContextFactories>();

            IDIContainer configurationContainer = DIContainerBuilderUtils.Build(levelConfiguration);

            ITaskDisposable<IStageUiContextInteractor> stageUiInteractor = await contextFactories.StageUi.Create(
                configurationContainer
                );
            ITaskDisposable<IStageContextInteractor> stageInteractor = await contextFactories.Stage.Create(
                configurationContainer,
                stageUiInteractor.Value.ToContainer()
                );

            await stageInteractor.Value.Load(cancellationToken);

            await loadingToken.Complete();

            stageInteractor.Value.Start();
        }
    }
}
