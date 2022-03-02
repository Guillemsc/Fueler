using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Fuel.UseCases.InitFuel
{
    public class InitFuelUseCase : IInitFuelUseCase
    {
        private readonly FuelData shipFuelData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly ILevelConfiguration levelConfiguration;

        public InitFuelUseCase(
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            ILevelConfiguration levelConfiguration
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.levelConfiguration = levelConfiguration;
        }

        public void Execute()
        {
            shipFuelData.MaxFuel = levelConfiguration.InitialFuel;
            shipFuelData.CurrentFuel = shipFuelData.MaxFuel;

            levelUiInteractor.SetFuel(decimal.ToSingle(shipFuelData.MaxFuel), decimal.ToSingle(shipFuelData.CurrentFuel));
        }
    }
}
