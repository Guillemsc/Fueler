using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.SetLevelAsLastPlayedLevel;
using Fueler.Content.Stage.Astrounats.UseCases.InitAstronauts;
using Fueler.Content.Stage.Fuel.UseCases.InitFuel;
using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;
using Fueler.Content.Stage.General.Actors;
using Fueler.Content.Stage.General.Data;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.General.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
using Fueler.Content.Stage.Ship.UseCases.ShipCollided;
using Fueler.Content.Stage.Ship.UseCases.ShipMoves;
using Fueler.Content.Stage.Time.UseCases.InitTime;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly ILevelConfiguration levelConfiguration;
        private readonly ILoadLevelUseCase loadLevelUseCase;
        private readonly ILoadShipUseCase loadShipUseCase;
        private readonly ISetShipInitialPositionUseCase setShipInitialPositionUseCase;
        private readonly ISetupShipCameraUseCase setupShipCameraUseCase;
        private readonly IShipCollidedUseCase shipCollidedUseCase;
        private readonly IInitFuelUseCase initFuelUseCase;
        private readonly IInitAstronautsUseCase initAstronautsUseCase;
        private readonly IInitTimeUseCase initTimeUseCase;
        private readonly IShipMovesUseCase shipMovesUseCase;
        private readonly ISetLevelAsLastPlayedLevelUseCase setLevelAsLastPlayedLevelUseCase;

        public LoadStageUseCase(
            StageStateData stageStateData,
            ILevelConfiguration levelConfiguration,
            ILoadLevelUseCase loadLevelUseCase,
            ILoadShipUseCase loadShipUseCase,
            ISetShipInitialPositionUseCase setShipInitialPositionUseCase,
            ISetupShipCameraUseCase setupShipCameraUseCase,
            IShipCollidedUseCase shipCollidedUseCase,
            IInitFuelUseCase initFuelUseCase,
            IInitAstronautsUseCase initAstronautsUseCase,
            IInitTimeUseCase initTimeUseCase,
            IShipMovesUseCase shipMovesUseCase,
            ISetLevelAsLastPlayedLevelUseCase setLevelAsLastPlayedLevelUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.levelConfiguration = levelConfiguration;
            this.loadLevelUseCase = loadLevelUseCase;
            this.loadShipUseCase = loadShipUseCase;
            this.setShipInitialPositionUseCase = setShipInitialPositionUseCase;
            this.setupShipCameraUseCase = setupShipCameraUseCase;
            this.shipCollidedUseCase = shipCollidedUseCase;
            this.initFuelUseCase = initFuelUseCase;
            this.initAstronautsUseCase = initAstronautsUseCase;
            this.initTimeUseCase = initTimeUseCase;
            this.shipMovesUseCase = shipMovesUseCase;
            this.setLevelAsLastPlayedLevelUseCase = setLevelAsLastPlayedLevelUseCase;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            setLevelAsLastPlayedLevelUseCase.Execute(levelConfiguration, serialize: true);

            loadLevelUseCase.Execute(levelConfiguration.LevelEntityPrefab, out LevelEntity levelEntity);

            initFuelUseCase.Execute();
            initAstronautsUseCase.Execute(levelEntity);
            initTimeUseCase.Execute();

            loadShipUseCase.Execute(out ShipEntity shipEntity);
            shipEntity.ShipController.CanMove = false;

            setShipInitialPositionUseCase.Execute(shipEntity);

            shipEntity.PhysicsCallbacks.OnPhysicsTriggerEnter2D += shipCollidedUseCase.Execute;
            shipEntity.ShipController.OnForwardOrBackward += shipMovesUseCase.Execute;

            setupShipCameraUseCase.Execute(shipEntity);

            stageStateData.Loaded = true;

            return Task.CompletedTask;
        }
    }
}
