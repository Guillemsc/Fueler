using Fueler.Content.Services.Audio;
using Juce.CoreUnity.Service;
using UnityEngine;

namespace Fueler.Content.Shared.Audio.Channels
{
    public class AudioChannelPlayer : MonoBehaviour
    {
        [SerializeField] private AudioChannelId channelId = default;

        public void Play(AudioClip audioClip)
        {
            bool audioServiceFound = ServiceLocator.TryGet(out IAudioService audioService);

            if(!audioServiceFound)
            {
                UnityEngine.Debug.LogError($"Tried to play audio at {nameof(AudioChannelPlayer)} but {nameof(IAudioService)} " +
                    $"could not be found on {nameof(ServiceLocator)}");
                return;
            }

            audioService.Play(audioClip, channelId);
        }
    }
}
