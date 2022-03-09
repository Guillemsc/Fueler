using Juce.Core.Time;
using Juce.CoreUnity.Time;
using System;
using UnityEngine;

namespace Fueler.Content.Stage.General.Actors
{
    public class AutodestroyAfterTime: MonoBehaviour 
    {
        [SerializeField] private float time = default;

        private readonly ITimer timer = new ScaledUnityTimer();

        private void Update()
        {
            TryAutoDestroy();
        }

        private void TryAutoDestroy()
        {
            if (!timer.Started && !timer.Paused)
            {
                timer.Start();
            }

            bool reached = timer.HasReached(TimeSpan.FromSeconds(time));

            if(!reached)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}
