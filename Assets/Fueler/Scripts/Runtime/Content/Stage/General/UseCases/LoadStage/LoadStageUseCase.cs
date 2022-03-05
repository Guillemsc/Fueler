using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Astrounats.UseCases.InitAstronauts;
using Fueler.Content.Stage.Fuel.UseCases.InitFuel;
using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.General.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
using Fueler.Content.Stage.Ship.UseCases.ShipCollided;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly ILevelConfiguration levelConfiguration;
        private readonly ILoadLevelUseCase loadLevelUseCase;
        private readonly ILoadShipUseCase loadShipUseCase;
        private readonly ISetShipInitialPositionUseCase setShipInitialPositionUseCase;
        private readonly ISetupShipCameraUseCase setupShipCameraUseCase;
        private readonly IShipCollidedUseCase shipCollidedUseCase;
        private readonly IInitFuelUseCase initFuelUseCase;
        private readonly IInitAstronautsUseCase initAstronautsUseCase;
        private readonly IShipFuelUsedUseCase shipFuelUsedUseCase;

        public LoadStageUseCase(
            ILevelConfiguration levelConfiguration,
            ILoadLevelUseCase loadLevelUseCase,
            ILoadShipUseCase loadShipUseCase,
            ISetShipInitialPositionUseCase setShipInitialPositionUseCase,
            ISetupShipCameraUseCase setupShipCameraUseCase,
                        IShipCollidedUseCase shipCollidedUseCase,
            IInitFuelUseCase initFuelUseCase,
            IInitAstronautsUseCase initAstronautsUseCase,
            IShipFuelUsedUseCase shipFuelUsedUseCase
            )
        {
            this.levelConfiguration = levelConfiguration;
            this.loadLevelUseCase = loadLevelUseCase;
            this.loadShipUseCase = loadShipUseCase;
            this.setShipInitialPositionUseCase = setShipInitialPositionUseCase;
            this.setupShipCameraUseCase = setupShipCameraUseCase;
            this.shipCollidedUseCase = shipCollidedUseCase;
            this.initFuelUseCase = initFuelUseCase;
            this.initAstronautsUseCase = initAstronautsUseCase;
            this.shipFuelUsedUseCase = shipFuelUsedUseCase;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            loadLevelUseCase.Execute(levelConfiguration.LevelEntityPrefab, out LevelEntity levelEntity);

            initFuelUseCase.Execute();
            initAstronautsUseCase.Execute(levelEntity);

            loadShipUseCase.Execute(out ShipEntity shipEntity);

            setShipInitialPositionUseCase.Execute(shipEntity);

            shipEntity.PhysicsCallbacks.OnPhysicsTriggerEnter2D += shipCollidedUseCase.Execute;
            shipEntity.ShipController.OnForwardOrBackward += shipFuelUsedUseCase.Execute;

            setupShipCameraUseCase.Execute(shipEntity);

            return Task.CompletedTask;
        }
    }
}
