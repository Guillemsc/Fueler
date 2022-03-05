using Fueler.Content.Stage.Ship.Visitors;
using Juce.TweenComponent;
using UnityEngine;

namespace Fueler.Content.Stage.Astrounats.Entities
{
    public class AstronautEntity : MonoBehaviour, IShipCollider
    {
        [Header("Tweens")]
        [SerializeField] private TweenPlayer collectTween = default;

        public bool Collected { get; set; }

        public void PlayCollect()
        {
            collectTween.Play();
        }

        public void Accept(IShipColliderVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
