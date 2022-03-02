using Fueler.Contexts.Shared.UseCases.LoadMainEntryPoint;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Juce.Core.DI.Builder;

namespace Fueler.Context.Shared.Installers
{
    public static class ContextSharedInstaller
    {
        public static void InstallContextShared(this IDIContainerBuilder container)
        {
            container.Bind<ILoadMainEntryPointUseCase>()
                .FromFunction(c => new LoadMainEntryPointUseCase(
                    ));

            container.Bind<IUnloadAndLoadStageUseCase>()
                .FromFunction(c => new UnloadAndLoadStageUseCase(
                    ));
        }
    }
}
