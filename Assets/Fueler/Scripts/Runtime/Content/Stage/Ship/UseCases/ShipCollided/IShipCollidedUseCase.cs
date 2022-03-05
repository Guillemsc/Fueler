using Juce.CoreUnity.Physics;

namespace Fueler.Content.Stage.Ship.UseCases.ShipCollided
{
    public interface IShipCollidedUseCase
    {
        void Execute(PhysicsCallbacks physicsCallbacks, Collider2DData collider2DData);
    }
}
