using Fueler.Content.Shared.Fuel.Configuration;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.StageUi.Ui.Level;
using System;
using UnityEngine;

namespace Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed
{
    public class ShipFuelUsedUseCase : IShipFuelUsedUseCase
    {
        private readonly FuelData shipFuelData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly IFuelConfiguration fuelConfiguration;

        public ShipFuelUsedUseCase(
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            IFuelConfiguration shipFuelConfiguration
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.fuelConfiguration = shipFuelConfiguration;
        }

        public void Execute()
        {
            float currentFuel = shipFuelData.CurrentFuel - fuelConfiguration.FuelConsumptionRate * Time.deltaTime;

            currentFuel = Math.Max(0, currentFuel);

            shipFuelData.CurrentFuel = currentFuel;

            levelUiInteractor.SetFuel(shipFuelData.MaxFuel, shipFuelData.CurrentFuel);
        }
    }
}
