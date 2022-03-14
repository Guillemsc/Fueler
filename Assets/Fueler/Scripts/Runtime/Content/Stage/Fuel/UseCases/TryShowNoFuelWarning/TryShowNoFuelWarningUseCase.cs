using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.General.Data;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Fuel.UseCases.TryShowNoFuelWarning
{
    public class TryShowNoFuelWarningUseCase : ITryShowNoFuelWarningUseCase
    {
        private readonly StageMessagesData stageMessagesData;
        private readonly FuelData shipFuelData;
        private readonly ILevelUiInteractor levelUiInteractor;

        public TryShowNoFuelWarningUseCase(
            StageMessagesData stageMessagesData,
            FuelData shipFuelData,
            ILevelUiInteractor levelUiInteractor
            )
        {
            this.stageMessagesData = stageMessagesData;
            this.shipFuelData = shipFuelData;
            this.levelUiInteractor = levelUiInteractor;
        }

        public void Execute()
        {
            if (shipFuelData.MaxFuel <= 0)
            {
                return;
            }

            if(shipFuelData.CurrentFuel > 0)
            {
                return;
            }

            if (stageMessagesData.NoFuelToasterShown)
            {
                return;
            }

            stageMessagesData.NoFuelToasterShown = true;

            levelUiInteractor.ShowToasterText("No energy left");
        }
    }
}
