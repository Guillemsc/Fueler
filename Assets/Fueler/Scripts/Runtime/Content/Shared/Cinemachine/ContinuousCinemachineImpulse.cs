using UnityEngine;
using Cinemachine;
using Juce.Core.Time;
using Juce.CoreUnity.Time;
using System;
using static Cinemachine.CinemachineImpulseManager;

namespace Fueler.Content.Shared.Cinemachine
{
    public class ContinuousCinemachineImpulse : MonoBehaviour
    {
        [CinemachineImpulseDefinitionProperty]
        [SerializeField] private CinemachineImpulseDefinition impulseDefinition = new CinemachineImpulseDefinition();

        private readonly ITimer timer = new ScaledUnityTimer();

        private ImpulseEvent impulseEvent;

        public bool Active { get; set; }

        private void Update()
        {            
            if(!Active)
            {
                timer.Pause();
                TryCancelEvent();
                return;
            }

            float eventLength = impulseDefinition.m_TimeEnvelope.m_AttackTime + impulseDefinition.m_TimeEnvelope.m_SustainTime;

            bool timePassed = timer.HasReached(TimeSpan.FromSeconds(eventLength)) || !timer.StartedAndNotPaused;

            if (!timePassed)
            {
                return;
            }

            timer.Restart();

            bool thereIsAlreadyPlayingEvent = impulseEvent != null;

            impulseEvent = impulseDefinition.CreateAndReturnEvent(transform.position, Vector3.one);
            
            if(thereIsAlreadyPlayingEvent)
            {
                impulseEvent.m_Envelope.m_SustainTime = impulseEvent.m_Envelope.m_SustainTime + impulseEvent.m_Envelope.m_AttackTime;
                impulseEvent.m_Envelope.m_AttackTime = 0.0f;
            }
        }

        private void TryCancelEvent()
        {
            if(impulseEvent == null)
            {
                return;
            }

            impulseEvent.Cancel(time: 0, forceNoDecay: false);

            impulseEvent = null;
        }
    }
}