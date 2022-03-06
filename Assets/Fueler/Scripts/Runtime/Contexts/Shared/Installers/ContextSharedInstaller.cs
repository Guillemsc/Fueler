using Fueler.Contexts.Shared.UseCases.ApplyGameSettings;
using Fueler.Contexts.Shared.UseCases.LoadMainEntryPoint;
using Fueler.Contexts.Shared.UseCases.LoadStage;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage;
using Fueler.Contexts.Shared.UseCases.UnloadStage;
using Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta;
using Juce.Core.DI.Builder;

namespace Fueler.Context.Shared.Installers
{
    public static class ContextSharedInstaller
    {
        public static void InstallContextShared(this IDIContainerBuilder container)
        {
            container.Bind<IApplyGameSettingsUseCase>()
                .FromFunction(c => new ApplyGameSettingsUseCase(
                    ));

            container.Bind<ILoadMainEntryPointUseCase>()
                .FromFunction(c => new LoadMainEntryPointUseCase(
                    c.Resolve<IApplyGameSettingsUseCase>()
                    ));

            container.Bind<ILoadStageUseCase>()
                .FromFunction(c => new LoadStageUseCase(
                    ));

            container.Bind<IUnloadStageUseCase>()
                .FromFunction(c => new UnloadStageUseCase(
                    ));

            container.Bind<IUnloadAndLoadStageUseCase>()
                .FromFunction(c => new UnloadAndLoadStageUseCase(
                    c.Resolve<ILoadStageUseCase>(),
                    c.Resolve<IUnloadStageUseCase>()
                    ));

            container.Bind<IUnloadMetaAndLoadStageUseCase>()
                .FromFunction(c => new UnloadMetaAndLoadStageUseCase(
                    c.Resolve<ILoadStageUseCase>()
                    ));

            container.Bind<IUnloadStageAndLoadMetaUseCase>()
                .FromFunction(c => new UnloadStageAndLoadMetaUseCase(
                    c.Resolve<IUnloadStageUseCase>()
                    ));
        }
    }
}
