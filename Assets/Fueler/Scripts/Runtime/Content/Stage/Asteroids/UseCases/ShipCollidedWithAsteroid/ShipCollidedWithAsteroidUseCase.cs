using Fueler.Content.Stage.Asteroids.Entities;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Asteroids.UseCases.ShipCollidedWithAsteroid
{
    public class ShipCollidedWithAsteroidUseCase : IShipCollidedWithAsteroidUseCase
    {
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;
        private readonly IEndStageUseCase endStageUseCase;

        public ShipCollidedWithAsteroidUseCase(
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository,
            IEndStageUseCase endStageUseCase
            )
        {
            this.shipEntityRepository = shipEntityRepository;
            this.endStageUseCase = endStageUseCase;
        }

        public void Execute(AsteroidEntity asteroidEntity)
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

            endStageUseCase.Execute(LevelEndData.FromShipDestroyed());
        }
    }
}
