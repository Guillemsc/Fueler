using Fueler.Content.Shared.Ship.Configuration;
using Fueler.Content.Stage.Ship.Data;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.UseCases.ShipFuelUsed
{
    public class ShipFuelUsedUseCase : IShipFuelUsedUseCase
    {
        private readonly ShipFuelData shipFuelData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly IShipFuelConfiguration shipFuelConfiguration;

        public ShipFuelUsedUseCase(
            ShipFuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            IShipFuelConfiguration shipFuelConfiguration
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.shipFuelConfiguration = shipFuelConfiguration;

            shipFuelData.MaxFuel = 1000;
            shipFuelData.CurrentFuel = shipFuelData.MaxFuel;
        }

        public void Execute()
        {
            shipFuelData.CurrentFuel -= shipFuelConfiguration.FuelConsumptionRate * Time.deltaTime;

            float currentFuelNormalized = 0.0f;

            if (shipFuelData.MaxFuel > 0)
            {
                currentFuelNormalized = shipFuelData.CurrentFuel / shipFuelData.MaxFuel;
            }

            levelUiInteractor.SetFuelNormalized(currentFuelNormalized);
        }
    }
}
