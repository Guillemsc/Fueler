using Juce.Tweening;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipMovementVfxController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ShipController shipController = default;

        [Header("Particle")]
        [SerializeField] private ParticleSystem particle = default;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource1 = default;
        [SerializeField] private AudioSource audioSource2 = default;
        [SerializeField] private float fadeInDuration = 0.3f;
        [SerializeField] private float fadeOutDuration = 0.3f;

        private bool needsToPlay;
        private bool playing;

        private ITween audioTween;

        private void Awake()
        {
            shipController.OnForwardOrBackward += OnForwardOrBackward;
        }

        private void Update()
        {
            TryStart();
            TryStop();
        }

        private void OnForwardOrBackward()
        {
            needsToPlay = true;
        }

        private void TryStart()
        {
            if(!needsToPlay)
            {
                return;
            }

            if(playing)
            {
                return;
            }

            playing = true;

            particle.Play();

            StartAudio();
        }

        private void TryStop()
        {
            if(needsToPlay)
            {
                needsToPlay = false;
                return;
            }

            if(!playing)
            {
                return;
            }

            playing = false;

            particle.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);

            StopAudio();
        }

        private void StartAudio()
        {
            if(audioTween != null)
            {
                audioTween.Kill();
            }

            ISequenceTween sequence = JuceTween.Sequence();

            sequence.AppendCallback(() =>
            {
                if(audioSource1.isPlaying)
                {
                    return;
                }

                audioSource1.Play();
                audioSource2.Play();
            });

            sequence.Append(audioSource1.TweenVolume(1, fadeInDuration));
            sequence.Join(audioSource2.TweenVolume(1, fadeInDuration));

            sequence.Play();

            audioTween = sequence;
        }

        private void StopAudio()
        {
            if (audioTween != null)
            {
                audioTween.Kill();
            }

            ISequenceTween sequence = JuceTween.Sequence();

            sequence.Append(audioSource1.TweenVolume(0, fadeOutDuration));
            sequence.Join(audioSource2.TweenVolume(0, fadeOutDuration));

            sequence.AppendCallback(() =>
            {
                audioSource1.Stop();
                audioSource2.Stop();
            });

            sequence.Play();

            audioTween = sequence;
        }
    }
}
