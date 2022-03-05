using Fueler.Content.Stage.Asteroids.UseCases.ShipCollidedWithAsteroid;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Juce.Core.DI.Builder;

namespace Fueler.Content.Stage.Asteroids.Installers
{
    public static class AsteroidsInstaller
    {
        public static void InstallAsteroids(this IDIContainerBuilder container)
        {
            container.Bind<IShipCollidedWithAsteroidUseCase>()
                .FromFunction(c => new ShipCollidedWithAsteroidUseCase(
                    c.Resolve<IEndStageUseCase>()
                    ));
        }
    }
}
