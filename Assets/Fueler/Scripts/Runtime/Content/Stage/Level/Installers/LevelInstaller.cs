using Fueler.Content.Stage.Level.Entities;
using Fueler.Content.Stage.Level.Factories;
using Fueler.Content.Stage.Level.State;
using Fueler.Content.Stage.Level.UseCases.EndLevel;
using Fueler.Content.Stage.Level.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Contexts.Stage;
using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Level.Installers
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

            container.Bind<ILoadLevelUseCase>().FromFunction(c => new LoadLevelUseCase(
                c.Resolve<IFactory<LevelEntityFactoryDefinition, IDisposable<LevelEntity>>>(),
                c.Resolve<ISingleRepository<IDisposable<LevelEntity>>>()
                ));

            container.Bind<IEndLevelUseCase>().FromFunction(c => new EndLevelUseCase(
                c.Resolve<LevelState>(),
                c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>()
                ));
        }
    }
}
