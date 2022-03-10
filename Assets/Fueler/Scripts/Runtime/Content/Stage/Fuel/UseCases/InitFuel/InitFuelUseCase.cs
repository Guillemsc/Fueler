using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Accessibility.UseCases.IsFuelInfinite;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Fuel.UseCases.InitFuel
{
    public class InitFuelUseCase : IInitFuelUseCase
    {
        private readonly FuelData shipFuelData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly ILevelConfiguration levelConfiguration;
        private readonly IIsFuelInfiniteUseCase isFuelInfiniteUseCase;

        public InitFuelUseCase(
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor,
            ILevelConfiguration levelConfiguration,
            IIsFuelInfiniteUseCase isFuelInfiniteUseCase
            )
        {
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
            this.levelConfiguration = levelConfiguration;
            this.isFuelInfiniteUseCase = isFuelInfiniteUseCase;
        }

        public void Execute()
        {
            bool isInfinite = isFuelInfiniteUseCase.Execute();

            if (!isInfinite)
            {
                shipFuelData.MaxFuel = levelConfiguration.InitialFuel;
                shipFuelData.CurrentFuel = shipFuelData.MaxFuel;
            }
            else
            {
                shipFuelData.MaxFuel = 0;
                shipFuelData.CurrentFuel = shipFuelData.MaxFuel;
            }

            levelUiInteractor.SetFuel(decimal.ToSingle(shipFuelData.MaxFuel), decimal.ToSingle(shipFuelData.CurrentFuel));
        }
    }
}
