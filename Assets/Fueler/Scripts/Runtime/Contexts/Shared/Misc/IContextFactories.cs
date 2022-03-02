using Fueler.Contexts.Camera;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Meta;
using Fueler.Contexts.Services;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.CoreUnity.Contexts;

namespace Fueler.Contexts.Shared
{
    public interface IContextFactories
    {
        IContextFactory<IServicesContextInteractor, ServicesContextInstance> Services { get; }
        IContextFactory<ICameraContextInteractor, CameraContextInstance> Camera { get; }
        IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> LoadingScreen { get; }
        IContextFactory<IMetaContextInteractor, MetaContextInstance> Meta { get; }
        IContextFactory<IStageUiContextInteractor, StageUiContextInstance> StageUi { get; }
        IContextFactory<IStageContextInteractor, StageContextInstance> Stage { get; }
    }
}
