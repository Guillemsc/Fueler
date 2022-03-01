using Juce.CoreUnity.Physics;
using UnityEngine;

namespace Fueler.Content.Stage.General.Entities
{
    public class LevelEntity : MonoBehaviour
    {
        [SerializeField] private CompositeCollider2D cameraConfiner = default;
        [SerializeField] private Transform startingPosition = default;
        [SerializeField] private PhysicsCallbacks endCallback = default;

        public CompositeCollider2D CameraConfiner => cameraConfiner;
        public Transform StartingPosition => startingPosition;
        public PhysicsCallbacks EndCallback => endCallback;
    }
}
