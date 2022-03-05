using Fueler.Content.Stage.Asteroids.Entities;
using Fueler.Content.Stage.Asteroids.UseCases.ShipCollidedWithAsteroid;
using Fueler.Content.Stage.Astrounats.Entities;
using Fueler.Content.Stage.Astrounats.UseCases.ShipCollidedWithAstronaut;
using Fueler.Content.Stage.Ship.Visitors;
using Juce.CoreUnity.Physics;

namespace Fueler.Content.Stage.Ship.UseCases.ShipCollided
{
    public class ShipCollidedUseCase : IShipCollidedUseCase, IShipColliderVisitor
    {
        private readonly IShipCollidedWithAsteroidUseCase shipCollidedWithAsteroidUseCase;
        private readonly IShipCollidedWithAstronautUseCase shipCollidedWithAstronautUseCase;

        public ShipCollidedUseCase(
            IShipCollidedWithAsteroidUseCase shipCollidedWithAsteroidUseCase,
            IShipCollidedWithAstronautUseCase shipCollidedWithAstronautUseCase
            )
        {
            this.shipCollidedWithAsteroidUseCase = shipCollidedWithAsteroidUseCase;
            this.shipCollidedWithAstronautUseCase = shipCollidedWithAstronautUseCase;
        }

        public void Execute(PhysicsCallbacks physicsCallbacks, Collider2DData collider2DData)
        {
            IShipCollider shipCollider = collider2DData.Collider2D.gameObject.GetComponentInParent<IShipCollider>();

            if (shipCollider == null)
            {
                return;
            }

            shipCollider.Accept(this);
        }

        public void Visit(AsteroidEntity entity)
        {
            shipCollidedWithAsteroidUseCase.Execute(entity);
        }

        public void Visit(AstronautEntity entity)
        {
            shipCollidedWithAstronautUseCase.Execute(entity);
        }
    }
}
