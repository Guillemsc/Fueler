using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.Ship.UseCases.SetupShipCamera
{
    public interface ISetupShipCameraUseCase
    {
        void Execute(ShipEntity shipEntity);
    }
}
