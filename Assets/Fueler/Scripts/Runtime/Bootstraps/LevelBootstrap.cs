using Fueler.Content.General.ConfigurationAssets.Levels;
using Fueler.Contexts.Camera;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Services;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Bootstraps;
using Juce.CoreUnity.Contexts;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Fueler.Bootstraps
{
    public class LevelBootstrap : Bootstrap
    {
        [SerializeField] private LevelConfigurationAsset levelConfiguration = default;

        protected override async Task Run()
        {
            ContextFactory<IServicesContextInteractor, ServicesContextInstance> servicesContextFactory
                = new ContextFactory<IServicesContextInteractor, ServicesContextInstance>(
                    "ServicesContext",
                    new ServicesContextInstaller()
                    );

            ContextFactory<ICameraContextInteractor, CameraContextInstance> cameraContextFactory
                = new ContextFactory<ICameraContextInteractor, CameraContextInstance>(
                    "CameraContext",
                    new CameraContextInstaller()
                    );

            ContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> loadingScreenContextFactory
                = new ContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance>(
                    "LoadingScreenContext",
                    new LoadingScreenContextInstaller()
                    );


            ContextFactory<IStageUiContextInteractor, StageUiContextInstance> stageUiContextFactory
                = new ContextFactory<IStageUiContextInteractor, StageUiContextInstance>(
                    "StageUiContext",
                    new StageUiContextInstaller()
                    );

            ContextFactory<IStageContextInteractor, StageContextInstance> stageContextFactory 
                = new ContextFactory<IStageContextInteractor, StageContextInstance>(
                    "StageContext",
                    new StageContextInstaller()
                    );

            await servicesContextFactory.Create();
            await cameraContextFactory.Create();

            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreenInteractor = await loadingScreenContextFactory.Create();
            ILoadingToken loadingToken = await loadingScreenInteractor.Value.Show(CancellationToken.None);

            ITaskDisposable<IStageUiContextInteractor> stageUiInteractor = await stageUiContextFactory.Create();
            ITaskDisposable<IStageContextInteractor> stageInteractor = await stageContextFactory.Create();

            await stageInteractor.Value.Load(levelConfiguration.ToConfiguration(), CancellationToken.None);

            loadingToken.Complete();
        }
    }
}
