using Juce.Core.DI.Builder;
using Fueler.Content.Services.Persistence;
using Fueler.Content.Shared.Levels.UseCases.IsLevelCompleted;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Services.Configuration;
using Fueler.Content.Shared.Levels.UseCases.IsFirstTimeExperience;
using Fueler.Content.Shared.Levels.UseCases.GetLastPlayedLevel;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Content.Shared.Levels.UseCases.TryGetLastUncompletedLevel;

namespace Fueler.Content.Meta.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDIContainerBuilder container)
        {
            container.Bind<ITryGetLevelByIndexUseCase>()
                .FromFunction(c => new TryGetLevelByIndexUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<IIsFirstTimeExperienceUseCase>()
                .FromFunction(c => new IsFirstTimeExperienceUseCase(
                    c.Resolve<IPersistenceService>().LevelsSerializable
                    ));

            container.Bind<IGetLastPlayedLevelUseCase>()
                .FromFunction(c => new GetLastPlayedLevelUseCase(
                    c.Resolve<IPersistenceService>().LevelsSerializable
                    ));

            container.Bind<ITryGetLevelIndexByLevelIdUseCase>()
                .FromFunction(c => new TryGetLevelIndexByLevelIdUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<IIsLevelCompletedUseCase>()
                .FromFunction(c => new IsLevelCompletedUseCase(
                     c.Resolve<IPersistenceService>().LevelsSerializable
                    ));

            container.Bind<ITryGetLastUncompletedLevelUseCase>()
                .FromFunction(c => new TryGetLastUncompletedLevelUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration,
                    c.Resolve<IIsLevelCompletedUseCase>()
                    ));
        }
    }
}
