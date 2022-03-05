using Juce.CoreUnity.Physics;
using Juce.TweenComponent;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipEntity : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ShipController shipController = default;
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer destroyTween = default;

        public PhysicsCallbacks PhysicsCallbacks => physicsCallbacks;
        public ShipController ShipController => shipController;

        public void PlayDestroy()
        {
            destroyTween.Play();
        }
    }
}
