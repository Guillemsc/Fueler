using Fueler.Content.Shared.Audio.Channels;
using Juce.Core.Time;
using Juce.CoreUnity.Time;
using Juce.Tweening;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace Fueler.Content.Services.Audio
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [Header("Configuration")]
        [SerializeField] private List<AudioChannel> channels = default;

        [Header("Static channels")]
        [SerializeField] private AudioChannelId generalMusicChannelId = default;

        [Header("Mixer groups")]
        [SerializeField] private AudioMixer audioMixer = default;
        [SerializeField] private string musicMixerAudioAttenuationParameter = default;
        [SerializeField] private string fxMixerAudioAttenuationParameter = default;

        private readonly Dictionary<AudioChannel, ITimer> cooldownTimers = new Dictionary<AudioChannel, ITimer>();

        public AudioChannelId GeneralMusicChannelId => generalMusicChannelId;


        public void Play(AudioClip audioClip, AudioChannelId audioChannelId, bool useCooldown = true)
        {
            if(audioChannelId == null)
            {
                UnityEngine.Debug.LogError($"{nameof(AudioChannelId)} is null", gameObject);
                return;
            }

            bool found = TryGetChannel(audioChannelId, out AudioChannel audioChannel);

            if(!found)
            {
                UnityEngine.Debug.LogError($"Audio Channel with id {audioChannelId.name} could not be found", gameObject);
                return;
            }

            Play(audioClip, audioChannel, useCooldown);
        }

        public void Play(AudioClip audioClip, AudioChannel audioChannel, bool useCooldown = true)
        {
            bool canPlayBecauseOfCooldown = CanPlayBecauseOfCooldown(audioChannel, useCooldown);

            if(!canPlayBecauseOfCooldown)
            {
                return;
            }

            audioChannel.AudioSource.outputAudioMixerGroup = audioChannel.AudioMixerGroup;

            if (audioChannel.AllowMultipleSimultaneous)
            {
                audioChannel.AudioSource.PlayOneShot(audioClip, audioChannel.Volume);
            }
            else
            {
                audioChannel.AudioSource.Stop();
                audioChannel.AudioSource.clip = audioClip;
                audioChannel.AudioSource.volume = audioChannel.Volume;
                audioChannel.AudioSource.Play();
            }
        }

        public Task StopFade(AudioChannelId audioChannelId, float fadeOutDuration, CancellationToken cancellationToken)
        {
            if (audioChannelId == null)
            {
                UnityEngine.Debug.LogError($"{nameof(AudioChannelId)} is null", gameObject);
                return Task.CompletedTask;
            }

            bool found = TryGetChannel(audioChannelId, out AudioChannel audioChannel);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Audio Channel with id {audioChannelId.name} could not be found", gameObject);
                return Task.CompletedTask;
            }

            if (audioChannel.AllowMultipleSimultaneous)
            {
                return Task.CompletedTask;
            }

            if(!audioChannel.AudioSource.isPlaying)
            {
                return Task.CompletedTask;
            }

            ITween tween = audioChannel.AudioSource.TweenVolume(0, fadeOutDuration);

            tween.Play();

            return tween.AwaitCompleteOrKill(cancellationToken);
        }

        public Task StartFade(AudioClip audioClip, AudioChannelId audioChannelId, float fadeInDuration, CancellationToken cancellationToken)
        {
            if (audioChannelId == null)
            {
                UnityEngine.Debug.LogError($"{nameof(AudioChannelId)} is null", gameObject);
                return Task.CompletedTask;
            }

            bool found = TryGetChannel(audioChannelId, out AudioChannel audioChannel);

            if (!found)
            {
                UnityEngine.Debug.LogError($"Audio Channel with id {audioChannelId.name} could not be found", gameObject);
                return Task.CompletedTask;
            }

            if (audioChannel.AllowMultipleSimultaneous)
            {
                return Task.CompletedTask;
            }

            audioChannel.AudioSource.volume = 0f;

            Play(audioClip, audioChannel, useCooldown: false);

            ITween tween = audioChannel.AudioSource.TweenVolume(audioChannel.Volume, fadeInDuration);

            tween.Play();

            return tween.AwaitCompleteOrKill(cancellationToken);
        }

        public void SetMusicMuted(bool muted)
        {
            float newValue = muted ? float.MinValue : 0f;

            audioMixer.SetFloat(musicMixerAudioAttenuationParameter, newValue);
        }

        public void SetFxMuted(bool muted)
        {
            float newValue = muted ? float.MinValue : 0f;

            audioMixer.SetFloat(fxMixerAudioAttenuationParameter, newValue);
        }

        private bool TryGetChannel(AudioChannelId audioChannelId, out AudioChannel audioChannel)
        {
            foreach(AudioChannel channel in channels)
            {
                if(channel.AudioChannelId == audioChannelId)
                {
                    audioChannel = channel;
                    return true;
                }
            }

            audioChannel = default;
            return false;
        }

        private ITimer GetTimer(AudioChannel audioChannel)
        {
            bool found = cooldownTimers.TryGetValue(audioChannel, out ITimer timer);

            if(!found)
            {
                timer = new UnscaledUnityTimer();
                cooldownTimers.Add(audioChannel, timer);
            }

            return timer;
        }

        private bool CanPlayBecauseOfCooldown(AudioChannel audioChannel, bool useCooldown)
        {
            if(!useCooldown)
            {
                return true;
            }

            if(audioChannel.Cooldown <= 0)
            {
                return true;
            }

            ITimer timer = GetTimer(audioChannel);

            if (timer.Started)
            {
                if (!timer.HasReached(TimeSpan.FromSeconds(audioChannel.Cooldown)))
                {
                    return false;
                }
            }

            timer.Restart();

            return true;
        }
    }
}
