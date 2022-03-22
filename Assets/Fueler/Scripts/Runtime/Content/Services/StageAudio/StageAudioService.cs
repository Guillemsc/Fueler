using Fueler.Content.Services.Audio;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Fueler.Content.Services.StageAudio
{
    public class StageAudioService : MonoBehaviour, IStageAudioService
    {
        [Header("Services")]
        [SerializeField] private AudioService audioService = default;

        [Header("Values")]
        [SerializeField] private AudioClip metaAudioClip = default;
        [SerializeField] private float fadeInTime = 1.0f;
        [SerializeField] private float fadeOutTime = 0.5f;

        private bool isPlaying;

        public Task Play(CancellationToken cancellationToken)
        {
            if(isPlaying)
            {
                return Task.CompletedTask;
            }

            isPlaying = true;

            return audioService.StartFade(
                metaAudioClip,
                audioService.GeneralMusicChannelId,
                fadeInTime,
                cancellationToken
                );
        }

        public Task Stop(CancellationToken cancellationToken)
        {
            if (!isPlaying)
            {
                return Task.CompletedTask;
            }

            isPlaying = false;

            return audioService.StopFade(
                audioService.GeneralMusicChannelId,
                fadeOutTime,
                cancellationToken
                );
        }
    }
}
