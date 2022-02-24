using Fueler.Contexts.Camera;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Services;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.CoreUnity.Contexts;

namespace Fueler.Contexts.Shared
{
    public class ContextFactories : IContextFactories
    {
        public IContextFactory<IServicesContextInteractor, ServicesContextInstance> Services { get; }
        public IContextFactory<ICameraContextInteractor, CameraContextInstance> Camera { get; }
        public IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> LoadingScreen { get; }
        public IContextFactory<IStageUiContextInteractor, StageUiContextInstance> StageUi { get; }
        public IContextFactory<IStageContextInteractor, StageContextInstance> Stage { get; }

        public ContextFactories(
            IContextFactory<IServicesContextInteractor, ServicesContextInstance> services,
            IContextFactory<ICameraContextInteractor, CameraContextInstance> camera,
            IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> loadingScreen,
            IContextFactory<IStageUiContextInteractor, StageUiContextInstance> stageUi,
            IContextFactory<IStageContextInteractor, StageContextInstance> stage
            )
        {
            Services = services;
            Camera = camera;
            LoadingScreen = loadingScreen;
            StageUi = stageUi;
            Stage = stage;
        }
    }
}
