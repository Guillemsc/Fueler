using Fueler.Content.Stage.Asteroids.Entities;

namespace Fueler.Content.Stage.Asteroids.UseCases.ShipCollidedWithAsteroid
{
    public interface IShipCollidedWithAsteroidUseCase
    {
        void Execute(AsteroidEntity asteroidEntity);
    }
}
