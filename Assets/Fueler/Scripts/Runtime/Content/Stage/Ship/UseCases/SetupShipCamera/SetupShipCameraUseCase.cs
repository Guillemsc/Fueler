using Cinemachine;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Ship.UseCases.SetupShipCamera
{
    public class SetupShipCameraUseCase : ISetupShipCameraUseCase
    {
        private readonly CinemachineVirtualCamera cinemachineVirtualCamera;
        private readonly CinemachineConfiner cameraConfiner;
        private readonly ISingleRepository<IDisposable<LevelEntity>> levelEntityRepository;

        public SetupShipCameraUseCase(
            CinemachineVirtualCamera cinemachineVirtualCamera,
            CinemachineConfiner cameraConfiner,
            ISingleRepository<IDisposable<LevelEntity>> levelEntityRepository
            )
        {
            this.cinemachineVirtualCamera = cinemachineVirtualCamera;
            this.cameraConfiner = cameraConfiner;
            this.levelEntityRepository = levelEntityRepository;
        }

        public void Execute(ShipEntity shipEntity)
        {
            cinemachineVirtualCamera.Follow = shipEntity.transform;
            cinemachineVirtualCamera.PreviousStateIsValid = false;

            bool levelFound = levelEntityRepository.TryGet(out IDisposable<LevelEntity> levelEntity);

            if (!levelFound)
            {
                UnityEngine.Debug.LogError("Tried to set ship initial position but level is not loaded");
                return;
            }

            cameraConfiner.m_BoundingShape2D = levelEntity.Value.CameraConfiner;

        }
    }
}
