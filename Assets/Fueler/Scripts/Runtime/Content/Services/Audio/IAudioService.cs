using Fueler.Content.Shared.Audio.Channels;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Fueler.Content.Services.Audio
{
    public interface IAudioService 
    {
        AudioChannelId GeneralMusicChannelId { get; }

        void Play(AudioClip audioClip, AudioChannelId audioChannelId, bool useCooldown = true);
        void Play(AudioClip audioClip, AudioChannel audioChannel, bool useCooldown = true);
        Task StopFade(AudioChannelId audioChannel, float fadeOutDuration, CancellationToken cancellationToken);
        Task StartFade(AudioClip audioClip, AudioChannelId audioChannel, float fadeInDuration, CancellationToken cancellationToken);
    }
}
