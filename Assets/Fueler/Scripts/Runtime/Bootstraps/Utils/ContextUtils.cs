using Fueler.Contexts.Camera;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Meta;
using Fueler.Contexts.Services;
using Fueler.Contexts.Shared;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;

namespace Fueler.Bootstraps
{
    public static class ContextUtils
    {
        public static IContextFactories CreateContextFactories()
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

            IContextFactory<IMetaContextInteractor, MetaContextInstance> metaContextFactory
                = new ContextFactory<IMetaContextInteractor, MetaContextInstance>(
                    "MetaContext",
                    new MetaContextInstaller()
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
                metaContextFactory,
                stageUiContextFactory,
                stageContextFactory
                );

            ServiceLocator.Register(contextFactories);

            return contextFactories;
        }
    }
}
