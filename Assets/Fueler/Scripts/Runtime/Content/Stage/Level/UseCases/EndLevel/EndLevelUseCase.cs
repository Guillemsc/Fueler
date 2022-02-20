using Fueler.Content.Stage.Data;
using Fueler.Content.Stage.Level.State;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Level.UseCases.EndLevel
{
    public class EndLevelUseCase : IEndLevelUseCase
    {
        private readonly LevelState levelState;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;

        public EndLevelUseCase(
            LevelState levelState,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository
            )
        {
            this.levelState = levelState;
            this.shipEntityRepository = shipEntityRepository;
        }

        public void Execute(LevelEndData levelEndedData)
        {
            if(levelState.Finished)
            {
                return;
            }

            levelState.Finished = true;

            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if(!found)
            {
                return;
            }

            if (levelEndedData.DestroyShip)
            {
                shipEntity.Value.ShipController.CanMove = false;
                shipEntity.Value.PlayDestroy();
            }
            else
            {
                shipEntity.Value.ShipController.Autobreak = true;
            }
        }
    }
}
