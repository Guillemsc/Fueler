using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.General.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
using Fueler.Content.Stage.Ship.UseCases.ShipFuelUsed;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly ILoadLevelUseCase loadLevelUseCase;
        private readonly ILoadShipUseCase loadShipUseCase;
        private readonly ISetShipInitialPositionUseCase setShipInitialPositionUseCase;
        private readonly ISetupShipCameraUseCase setupShipCameraUseCase;
        private readonly IShipFuelUsedUseCase shipFuelUsedUseCase;

        public LoadStageUseCase(
            ILoadLevelUseCase loadLevelUseCase,
            ILoadShipUseCase loadShipUseCase,
            ISetShipInitialPositionUseCase setShipInitialPositionUseCase,
            ISetupShipCameraUseCase setupShipCameraUseCase,
            IShipFuelUsedUseCase shipFuelUsedUseCase
            )
        {
            this.loadLevelUseCase = loadLevelUseCase;
            this.loadShipUseCase = loadShipUseCase;
            this.setShipInitialPositionUseCase = setShipInitialPositionUseCase;
            this.setupShipCameraUseCase = setupShipCameraUseCase;
            this.shipFuelUsedUseCase = shipFuelUsedUseCase;
        }

        public Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            loadLevelUseCase.Execute(levelConfiguration.LevelEntityPrefab, out _);

            loadShipUseCase.Execute(out ShipEntity shipEntity);

            shipEntity.ShipController.OnForwardOrBackward += shipFuelUsedUseCase.Execute;

            setShipInitialPositionUseCase.Execute(shipEntity);

            setupShipCameraUseCase.Execute(shipEntity);

            return Task.CompletedTask;
        }
    }
}
