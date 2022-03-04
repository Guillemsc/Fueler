using Juce.Core.DI.Builder;
using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;

namespace Fueler.Content.StageUi.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDIContainerBuilder container)
        {
            container.Bind<IWaitUnscaledTimeUseCase>()
                .FromFunction(c => new WaitUnscaledTimeUseCase());

            container.Bind<IReloadLevelUseCase>()
                .FromFunction(c => new ReloadLevelUseCase(
                    c.Resolve<ILevelConfiguration>(),
                    c.Resolve<IUnloadAndLoadStageUseCase>()
                    ));
        }
    }
}
