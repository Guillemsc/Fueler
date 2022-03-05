using Juce.TweenComponent;
using UnityEngine;

namespace Fueler.Content.Stage.Astrounats.Entities
{
    public class AstronautEntity : MonoBehaviour
    {
        [Header("Tweens")]
        [SerializeField] private TweenPlayer collectTween = default;

        public void PlayCollect()
        {
            collectTween.Play();
        }
    }
}
