using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Context.Shared.Installers;
using Fueler.Contexts.Camera;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Services;
using Fueler.Contexts.Shared;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Bootstraps.Utils
{
    public static class LevelBootstrapUtils
    {
        public static async Task Run(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            IContextFactory<IServicesContextInteractor, ServicesContextInstance> servicesContextFactory
               = new ContextFactory<IServicesContextInteractor, ServicesContextInstance>(
                   "ServicesContext",
                   new ServicesContextInstaller()
                   );

            IContextFactory<ICameraContextInteractor, CameraContextInstance> cameraContextFactory
                = new ContextFactory<ICameraContextInteractor, CameraContextInstance>(
                    "CameraContext",
                    new CameraContextInstaller()
                    );

            IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> loadingScreenContextFactory
                = new ContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance>(
                    "LoadingScreenContext",
                    new LoadingScreenContextInstaller()
                    );

            IContextFactory<IStageUiContextInteractor, StageUiContextInstance> stageUiContextFactory
                = new ContextFactory<IStageUiContextInteractor, StageUiContextInstance>(
                    "StageUiContext",
                    new StageUiContextInstaller()
                    );

            IContextFactory<IStageContextInteractor, StageContextInstance> stageContextFactory
                = new ContextFactory<IStageContextInteractor, StageContextInstance>(
                    "StageContext",
                    new StageContextInstaller()
                    );

            IContextFactories contextFactories = new ContextFactories(
                servicesContextFactory,
                cameraContextFactory,
                loadingScreenContextFactory,
                stageUiContextFactory,
                stageContextFactory
                );

            ServiceLocator.Register(contextFactories);

            await servicesContextFactory.Create();
            await cameraContextFactory.Create();
            await loadingScreenContextFactory.Create();

            IDIContainerBuilder sharedContextBuilder = new DIContainerBuilder();
            {
                sharedContextBuilder.InstallContextShared();
            }
            IDIContainer sharedContextContainer = sharedContextBuilder.Build();

            IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase = sharedContextContainer.Resolve<IUnloadAndLoadStageUseCase>();

            await unloadAndLoadStageUseCase.Execute(levelConfiguration, cancellationToken);
        }
    }
}
