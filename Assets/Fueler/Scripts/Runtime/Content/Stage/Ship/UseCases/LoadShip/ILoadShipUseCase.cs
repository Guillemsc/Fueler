using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.Ship.UseCases.LoadShip
{
    public interface ILoadShipUseCase
    {
        bool Execute(out ShipEntity shipEntity);
    }
}
