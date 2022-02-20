using Fueler.Content.Stage.Configuration;
using Fueler.Content.Stage.Level.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage.UseCases.Load
{
    public class LoadUseCase : ILoadUseCase
    {
        private readonly ILoadLevelUseCase loadLevelUseCase;
        private readonly ILoadShipUseCase loadShipUseCase;
        private readonly ISetShipInitialPositionUseCase setShipInitialPositionUseCase;
        private readonly ISetupShipCameraUseCase setupShipCameraUseCase;

        public LoadUseCase(
            ILoadLevelUseCase loadLevelUseCase,
            ILoadShipUseCase loadShipUseCase,
            ISetShipInitialPositionUseCase setShipInitialPositionUseCase,
            ISetupShipCameraUseCase setupShipCameraUseCase
            )
        {
            this.loadLevelUseCase = loadLevelUseCase;
            this.loadShipUseCase = loadShipUseCase;
            this.setShipInitialPositionUseCase = setShipInitialPositionUseCase;
            this.setupShipCameraUseCase = setupShipCameraUseCase;
        }

        public Task Execute(LevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            loadLevelUseCase.Execute(levelConfiguration.LevelEntityPrefab, out _);

            loadShipUseCase.Execute(out ShipEntity shipEntity);

            setShipInitialPositionUseCase.Execute(shipEntity);

            setupShipCameraUseCase.Execute(shipEntity);

            return Task.CompletedTask;
        }
    }
}
