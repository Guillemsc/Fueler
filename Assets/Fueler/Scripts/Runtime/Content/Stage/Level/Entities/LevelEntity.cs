using Juce.CoreUnity.Physics;
using UnityEngine;

namespace Fueler.Content.Stage.Level.Entities
{
    public class LevelEntity : MonoBehaviour
    {
        [SerializeField] private PolygonCollider2D cameraConfiner = default;
        [SerializeField] private Transform startingPosition = default;
        [SerializeField] private PhysicsCallbacks endCallback = default;

        public PolygonCollider2D CameraConfiner => cameraConfiner;
        public Transform StartingPosition => startingPosition;
        public PhysicsCallbacks EndCallback => endCallback;
    }
}
