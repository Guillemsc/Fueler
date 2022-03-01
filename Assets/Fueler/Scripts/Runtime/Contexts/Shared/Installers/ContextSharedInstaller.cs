using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Juce.Core.DI.Builder;

namespace Fueler.Context.Shared.Installers
{
    public static class ContextSharedInstaller
    {
        public static void InstallContextShared(this IDIContainerBuilder container)
        { 
            container.Bind<IUnloadAndLoadStageUseCase>()
                .FromFunction(c => new UnloadAndLoadStageUseCase(
                    ));
        }
    }
}
