using Juce.TweenComponent;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipEntity : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ShipController shipController = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer destroyTween = default;

        public ShipController ShipController => shipController;

        public void PlayDestroy()
        {
            destroyTween.Play();
        }
    }
}
