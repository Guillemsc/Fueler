using Fueler.Content.Stage.General.UseCases.TryEndStage;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Ship.UseCases.ShipCollidedWithShipKiller
{
    public class ShipCollidedWithShipKillerUseCase : IShipCollidedWithShipKillerUseCase
    {
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;
        private readonly ITryEndStageUseCase tryEndStageUseCase;

        public ShipCollidedWithShipKillerUseCase(
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository,
            ITryEndStageUseCase tryEndStageUseCase
            )
        {
            this.shipEntityRepository = shipEntityRepository;
            this.tryEndStageUseCase = tryEndStageUseCase;
        }

        public void Execute(ShipKillerEntity shipKillerEntity)
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if(!found)
            {
                return;
            }
            
            if(shipEntity.Value.Immortal)
            {
                return;
            }

            tryEndStageUseCase.Execute(ShipDestroyedLevelFinishedCause.Instance);
        }
    }
}
