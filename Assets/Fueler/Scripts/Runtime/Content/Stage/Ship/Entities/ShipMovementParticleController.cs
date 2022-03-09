using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipMovementParticleController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ShipController shipController = default;

        [Header("Particle")]
        [SerializeField] private ParticleSystem particleSystem = default;

        private bool needsToPlay;

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

            if(particleSystem.isEmitting)
            {
                return;
            }

            particleSystem.Play();
        }

        private void TryStop()
        {
            if(needsToPlay)
            {
                needsToPlay = false;
                return;
            }

            particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
