using Cinemachine;
using Fueler.Content.Stage.Ship.Entities;
using UnityEngine;

namespace Fueler.Contexts.Stage
{
    public class StageContextInstance : MonoBehaviour
    {
        [Header("Level")]
        [SerializeField] private Transform levelEntityParent = default;

        [Header("Ship")]
        [SerializeField] private ShipEntity shipEntityPrefab = default;
        [SerializeField] private Transform shipEntityParent = default;

        [Header("Camera")]
        [SerializeField] private CinemachineVirtualCamera shipVirtualCamera = default;
        [SerializeField] private CinemachineConfiner cameraConfiner = default;

        public Transform LevelEntityParent => levelEntityParent;

        public ShipEntity ShipEntityPrefab => shipEntityPrefab;
        public Transform ShipEntityParent => shipEntityParent;

        public CinemachineVirtualCamera ShipVirtualCamera => shipVirtualCamera;
        public CinemachineConfiner CameraConfiner => cameraConfiner;
    }
}
