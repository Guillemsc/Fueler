using Fueler.Content.Stage.Configuration;
using Fueler.Content.Stage.Level.Entities;
using Fueler.Contexts.Camera;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Stage;
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
        [SerializeField] private LevelEntity levelEntityPrefab = default;

        protected override async Task Run()
        {
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

            ContextFactory<IStageContextInteractor, StageContextInstance> stageContextFactory 
                = new ContextFactory<IStageContextInteractor, StageContextInstance>(
                    "StageContext",
                    new StageContextInstaller()
                    );

            await cameraContextFactory.Create();

            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreenInteractor = await loadingScreenContextFactory.Create();
            ILoadingToken loadingToken = await loadingScreenInteractor.Value.Show(CancellationToken.None);

            ITaskDisposable<IStageContextInteractor> stageInteractor = await stageContextFactory.Create();

            await stageInteractor.Value.Load(new LevelConfiguration(levelEntityPrefab), CancellationToken.None);

            loadingToken.Complete();
        }
    }
}
