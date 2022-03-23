using Fueler.Content.Stage.Ship.Visitors;
using Juce.TweenComponent;
using UnityEngine;

namespace Fueler.Content.Stage.General.Entities
{
    public class LevelEndEntity : MonoBehaviour, IShipCollider
    {
        [SerializeField] private TweenPlayer completedTween = default;

        public void PlayCompleted()
        {
            completedTween.Play();
        }

        public void Accept(IShipColliderVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
