using Fueler.Content.Stage.Astrounats.Entities;
using Juce.CoreUnity.Physics;
using System.Collections.Generic;
using UnityEngine;

namespace Fueler.Content.Stage.General.Entities
{
    public class LevelEntity : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private CompositeCollider2D cameraConfiner = default;
        [SerializeField] private Transform startingPosition = default;
        [SerializeField] private PhysicsCallbacks endCallback = default;

        [Header("Items")]
        [SerializeField] private List<AstronautEntity> astronatus = default;

        public CompositeCollider2D CameraConfiner => cameraConfiner;
        public Transform StartingPosition => startingPosition;
        public PhysicsCallbacks EndCallback => endCallback;

        public IReadOnlyList<AstronautEntity> Astronauts => astronatus;
    }
}
