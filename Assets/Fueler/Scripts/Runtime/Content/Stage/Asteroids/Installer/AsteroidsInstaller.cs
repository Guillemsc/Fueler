using Fueler.Content.Stage.Asteroids.UseCases.ShipCollidedWithAsteroid;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Asteroids.Installers
{
    public static class AsteroidsInstaller
    {
        public static void InstallAsteroids(this IDIContainerBuilder container)
        {
            container.Bind<IShipCollidedWithAsteroidUseCase>()
                .FromFunction(c => new ShipCollidedWithAsteroidUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>(),
                    c.Resolve<IEndStageUseCase>()
                    ));
        }
    }
}
