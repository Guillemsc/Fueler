using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition
{
    public class SetShipInitialPositionUseCase : ISetShipInitialPositionUseCase
    {
        private readonly ISingleRepository<IDisposable<LevelEntity>> levelEntityRepository;

        public SetShipInitialPositionUseCase(
            ISingleRepository<IDisposable<LevelEntity>> levelEntityRepository
            )
        {
            this.levelEntityRepository = levelEntityRepository;
        }

        public void Execute(ShipEntity shipEntity)
        {
            bool levelFound = levelEntityRepository.TryGet(out IDisposable<LevelEntity> levelEntity);

            if(!levelFound)
            {
                UnityEngine.Debug.LogError("Tried to set ship initial position but level is not loaded");
                return;
            }

            Transform initialTransform = levelEntity.Value.StartingPosition;

            shipEntity.transform.SetPositionAndRotation(
                initialTransform.transform.position,
                initialTransform.transform.rotation
                );
        }
    }
}
