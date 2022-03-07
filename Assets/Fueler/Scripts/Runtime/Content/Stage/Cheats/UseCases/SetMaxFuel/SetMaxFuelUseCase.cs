using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;

namespace Fueler.Content.Stage.Cheats.UseCases.SetMaxFuel
{
    public class SetMaxFuelUseCase : ISetMaxFuelUseCase
    {
        private readonly FuelData fuelData;
        private readonly IShipFuelUsedUseCase shipFuelUsedUseCase;

        public SetMaxFuelUseCase(
            FuelData fuelData,
            IShipFuelUsedUseCase shipFuelUsedUseCase
            )
        {
            this.fuelData = fuelData;
            this.shipFuelUsedUseCase = shipFuelUsedUseCase;
        }

        public void Execute()
        {
            fuelData.MaxFuel = 99999;
            fuelData.CurrentFuel = fuelData.MaxFuel;

            shipFuelUsedUseCase.Execute();
        }
    }
}
