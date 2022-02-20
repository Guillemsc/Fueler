
using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition
{
    public interface ISetShipInitialPositionUseCase
    {
        void Execute(ShipEntity shipEntity);
    }
}
