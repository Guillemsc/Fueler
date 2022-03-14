using Fueler.Content.Shared.Fuel.Configuration;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Fuel.UseCases.CheckShipMovementIfNoFuel;
using Fueler.Content.Stage.Fuel.UseCases.TryShowLowFuelWarning;
using Fueler.Content.Stage.Fuel.UseCases.TryShowNoFuelWarning;
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
        private readonly ITryShowLowFuelWarningUseCase tryShowLowFuelWarningUseCase;
        private readonly ITryShowNoFuelWarningUseCase tryShowNoFuelWarningUseCase;
        private readonly ICheckShipMovementIfNoFuelUseCase checkShipMovementIfNoFuelUseCase;

        public ShipFuelUsedUseCase(
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            IFuelConfiguration fuelConfiguration,
            ITryShowLowFuelWarningUseCase tryShowLowFuelWarningUseCase,
            ITryShowNoFuelWarningUseCase tryShowNoFuelWarningUseCase,
            ICheckShipMovementIfNoFuelUseCase checkShipMovementIfNoFuelUseCase
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.fuelConfiguration = fuelConfiguration;
            this.tryShowLowFuelWarningUseCase = tryShowLowFuelWarningUseCase;
            this.tryShowNoFuelWarningUseCase = tryShowNoFuelWarningUseCase;
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

            tryShowLowFuelWarningUseCase.Execute();
            tryShowNoFuelWarningUseCase.Execute();

            checkShipMovementIfNoFuelUseCase.Execute();
        }
    }
}
