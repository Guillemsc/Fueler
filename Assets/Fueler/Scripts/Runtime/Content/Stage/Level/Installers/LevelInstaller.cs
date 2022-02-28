using Fueler.Content.Services.Configuration;
using Fueler.Content.Shared.Levels.UseCases.LoadNextLevel;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.General.Factories;
using Fueler.Content.Stage.General.State;
using Fueler.Content.Stage.General.UseCases.LoadLevel;
using Fueler.Contexts.Stage;
using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.General.Installers
{
    public static class LevelInstaller
    {
        public static void InstallLevel(this IDIContainerBuilder container)
        {
            container.Bind<LevelState>().FromNew();

            container.Bind<IFactory<LevelEntityFactoryDefinition, IDisposable<LevelEntity>>>().FromFunction(c => new LevelEntityFactory(
                c.Resolve<StageContextInstance>().LevelEntityParent
                ));

            container.Bind<ISingleRepository<IDisposable<LevelEntity>>>().FromInstance(
                new SimpleSingleRepository<IDisposable<LevelEntity>>()
                );

            container.Bind<ITryGetLevelIndexByLevelIdUseCase>()
                .FromFunction(c => new TryGetLevelIndexByLevelIdUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<ITryGetLevelByIndexUseCase>()
                .FromFunction(c => new TryGetLevelByIndexUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration
                    ));

            container.Bind<ILoadNextLevelUseCase>()
                .FromFunction(c => new LoadNextLevelUseCase(
                    c.Resolve<ITryGetLevelIndexByLevelIdUseCase>(),
                    c.Resolve<ITryGetLevelByIndexUseCase>()
                    ));

            container.Bind<ILoadLevelUseCase>().FromFunction(c => new LoadLevelUseCase(
                c.Resolve<IFactory<LevelEntityFactoryDefinition, IDisposable<LevelEntity>>>(),
                c.Resolve<ISingleRepository<IDisposable<LevelEntity>>>()
                ));
        }
    }
}
