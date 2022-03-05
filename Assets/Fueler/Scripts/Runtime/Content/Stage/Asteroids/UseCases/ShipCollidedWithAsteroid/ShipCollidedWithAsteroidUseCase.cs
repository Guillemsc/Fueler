using Fueler.Content.Stage.Asteroids.Entities;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.Level.Data;

namespace Fueler.Content.Stage.Asteroids.UseCases.ShipCollidedWithAsteroid
{
    public class ShipCollidedWithAsteroidUseCase : IShipCollidedWithAsteroidUseCase
    {
        private readonly IEndStageUseCase endStageUseCase;

        public ShipCollidedWithAsteroidUseCase(
            IEndStageUseCase endStageUseCase
            )
        {
            this.endStageUseCase = endStageUseCase;
        }

        public void Execute(AsteroidEntity asteroidEntity)
        {
            endStageUseCase.Execute(LevelEndData.FromShipDestroyed());
        }
    }
}
