using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.Ship.UseCases.ShipCollidedWithShipKiller
{
    public interface IShipCollidedWithShipKillerUseCase
    {
        void Execute(ShipKillerEntity asteroidEntity);
    }
}
