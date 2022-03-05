using Juce.Core.DI.Builder;
using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Fueler.Content.Shared.Levels.UseCases.LoadNextLevel;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Content.Services.Configuration;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;

namespace Fueler.Content.StageUi.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDIContainerBuilder container)
        {
            container.Bind<IWaitUnscaledTimeUseCase>()
                .FromFunction(c => new WaitUnscaledTimeUseCase());

            container.Bind<ITryGetLevelIndexByLevelIdUseCase>()
                .FromFunction(c => new TryGetLevelIndexByLevelIdUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<ITryGetLevelByIndexUseCase>()
                .FromFunction(c => new TryGetLevelByIndexUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<IReloadLevelUseCase>()
                .FromFunction(c => new ReloadLevelUseCase(
                    c.Resolve<ILevelConfiguration>(),
                    c.Resolve<IUnloadAndLoadStageUseCase>()
                    ));

            container.Bind<ILoadNextLevelUseCase>()
                .FromFunction(c => new LoadNextLevelUseCase(
                    c.Resolve<ILevelConfiguration>(),
                    c.Resolve<ITryGetLevelIndexByLevelIdUseCase>(),
                    c.Resolve<ITryGetLevelByIndexUseCase>(),
                    c.Resolve<IUnloadAndLoadStageUseCase>()
                    ));
        }
    }
}
