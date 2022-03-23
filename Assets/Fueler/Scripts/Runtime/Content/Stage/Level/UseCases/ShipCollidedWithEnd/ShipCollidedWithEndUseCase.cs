using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.General.UseCases.TryEndStage;
using Fueler.Content.Stage.Level.Data;

namespace Fueler.Content.Stage.General.UseCases.ShipCollidedWithEnd
{
    public class ShipCollidedWithEndUseCase : IShipCollidedWithEndUseCase
    {
        private readonly ITryEndStageUseCase tryEndStageUseCase;

        public ShipCollidedWithEndUseCase(
            ITryEndStageUseCase tryEndStageUseCase
            )
        {
            this.tryEndStageUseCase = tryEndStageUseCase;
        }

        public void Execute(LevelEndEntity entity)
        {
            tryEndStageUseCase.Execute(new ReachedEndDestinationLevelFinishedCause(entity));
        }
    }
}
