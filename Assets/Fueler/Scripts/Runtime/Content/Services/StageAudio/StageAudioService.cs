using Fueler.Content.Services.Audio;
using System.Collections.Generic;
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
        [SerializeField] private List<AudioClip> audioClips = default;
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

            AudioClip randomClip = GetRandom();

            return audioService.StartFade(
                randomClip,
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

        public AudioClip GetRandom()
        {
            int randomIndex = UnityEngine.Random.Range(0, audioClips.Count);

            return audioClips[randomIndex];
        }
    }
}
