using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Fuel.UseCases.CheckShipMovementIfNoFuel
{
    public class CheckShipMovementIfNoFuelUseCase : ICheckShipMovementIfNoFuelUseCase
    {
        private readonly FuelData shipFuelData;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;

        public CheckShipMovementIfNoFuelUseCase(
            FuelData shipFuelData,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository
            )
        {
            this.shipFuelData = shipFuelData;
            this.shipEntityRepository = shipEntityRepository;
        }

        public void Execute()
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if(!found)
            {
                return;
            }

            bool hasFuel = shipFuelData.CurrentFuel > 0;

            shipEntity.Value.ShipController.CanInputForward = hasFuel;
        }
    }
}
