﻿using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Fuel.UseCases.InitFuel;
using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;
using Fueler.Content.Stage.General.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
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
        private readonly IInitFuelUseCase initFuelUseCase;
        private readonly IShipFuelUsedUseCase shipFuelUsedUseCase;

        public LoadStageUseCase(
            ILevelConfiguration levelConfiguration,
            ILoadLevelUseCase loadLevelUseCase,
            ILoadShipUseCase loadShipUseCase,
            ISetShipInitialPositionUseCase setShipInitialPositionUseCase,
            ISetupShipCameraUseCase setupShipCameraUseCase,
            IInitFuelUseCase initFuelUseCase,
            IShipFuelUsedUseCase shipFuelUsedUseCase
            )
        {
            this.levelConfiguration = levelConfiguration;
            this.loadLevelUseCase = loadLevelUseCase;
            this.loadShipUseCase = loadShipUseCase;
            this.setShipInitialPositionUseCase = setShipInitialPositionUseCase;
            this.setupShipCameraUseCase = setupShipCameraUseCase;
            this.initFuelUseCase = initFuelUseCase;
            this.shipFuelUsedUseCase = shipFuelUsedUseCase;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            initFuelUseCase.Execute();

            loadLevelUseCase.Execute(levelConfiguration.LevelEntityPrefab, out _);

            loadShipUseCase.Execute(out ShipEntity shipEntity);

            shipEntity.ShipController.OnForwardOrBackward += shipFuelUsedUseCase.Execute;

            setShipInitialPositionUseCase.Execute(shipEntity);

            setupShipCameraUseCase.Execute(shipEntity);

            return Task.CompletedTask;
        }
    }
}