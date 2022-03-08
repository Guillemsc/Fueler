using Fueler.Content.Shared.Fuel.Configuration;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Fuel.UseCases.CheckShipMovementIfNoFuel;
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
        private readonly ICheckShipMovementIfNoFuelUseCase checkShipMovementIfNoFuelUseCase;

        public ShipFuelUsedUseCase(
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            IFuelConfiguration fuelConfiguration,
            ICheckShipMovementIfNoFuelUseCase checkShipMovementIfNoFuelUseCase
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.fuelConfiguration = fuelConfiguration;
            this.checkShipMovementIfNoFuelUseCase = checkShipMovementIfNoFuelUseCase;
        }

        public void Execute()
        {
            if (shipFuelData.MaxFuel <= 0)
            {
                return;
            }

            decimal currentFuel = shipFuelData.CurrentFuel - (decimal)fuelConfiguration.FuelConsumptionRate * (decimal)Time.deltaTime;

            currentFuel = Math.Max(0, currentFuel);

            shipFuelData.CurrentFuel = currentFuel;

            levelUiInteractor.SetFuel(decimal.ToSingle(shipFuelData.MaxFuel), decimal.ToSingle(shipFuelData.CurrentFuel));

            checkShipMovementIfNoFuelUseCase.Execute();
        }
    }
}
