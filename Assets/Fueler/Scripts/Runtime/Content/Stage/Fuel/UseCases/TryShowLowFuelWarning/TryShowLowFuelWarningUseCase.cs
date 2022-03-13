using Fueler.Content.Shared.Fuel.Configuration;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Fuel.UseCases.TryShowLowFuelWarning
{
    public class TryShowLowFuelWarningUseCase : ITryShowLowFuelWarningUseCase
    {
        private readonly FuelData shipFuelData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly IFuelConfiguration fuelConfiguration;

        public TryShowLowFuelWarningUseCase(
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            IFuelConfiguration fuelConfiguration
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.fuelConfiguration = fuelConfiguration;
        }

        public void Execute()
        {            
            if(shipFuelData.ShowedLowFuelWarning)
            {
                return;
            }

            float currentFuelNormalized = 0.0f;

            if (shipFuelData.MaxFuel > 0)
            {
                currentFuelNormalized = (float)(shipFuelData.CurrentFuel / shipFuelData.MaxFuel);
            }

            if(currentFuelNormalized > fuelConfiguration.LowFuelIndicatorNormalized)
            {
                return;
            }

            shipFuelData.ShowedLowFuelWarning = true;

            levelUiInteractor.ShowToasterText("Low energy");
            levelUiInteractor.EnableLowFuelWarning();
        }
    }
}
