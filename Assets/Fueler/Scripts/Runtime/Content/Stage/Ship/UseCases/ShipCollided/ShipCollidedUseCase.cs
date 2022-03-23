using Fueler.Content.Stage.Astrounats.Entities;
using Fueler.Content.Stage.Astrounats.UseCases.ShipCollidedWithAstronaut;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.General.UseCases.ShipCollidedWithEnd;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.UseCases.ShipCollidedWithShipKiller;
using Fueler.Content.Stage.Ship.Visitors;
using Juce.CoreUnity.Physics;

namespace Fueler.Content.Stage.Ship.UseCases.ShipCollided
{
    public class ShipCollidedUseCase : IShipCollidedUseCase, IShipColliderVisitor
    {
        private readonly IShipCollidedWithEndUseCase shipCollidedWithEndUseCase;
        private readonly IShipCollidedWithShipKillerUseCase shipCollidedWithShipKillerUseCase;
        private readonly IShipCollidedWithAstronautUseCase shipCollidedWithAstronautUseCase;

        public ShipCollidedUseCase(
            IShipCollidedWithEndUseCase shipCollidedWithEndUseCase,
            IShipCollidedWithShipKillerUseCase shipCollidedWithShipKillerUseCase,
            IShipCollidedWithAstronautUseCase shipCollidedWithAstronautUseCase
            )
        {
            this.shipCollidedWithEndUseCase = shipCollidedWithEndUseCase;
            this.shipCollidedWithShipKillerUseCase = shipCollidedWithShipKillerUseCase;
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

        public void Visit(LevelEndEntity entity)
        {
            shipCollidedWithEndUseCase.Execute(entity);
        }

        public void Visit(ShipKillerEntity entity)
        {
            shipCollidedWithShipKillerUseCase.Execute(entity);
        }

        public void Visit(AstronautEntity entity)
        {
            shipCollidedWithAstronautUseCase.Execute(entity);
        }
    }
}
