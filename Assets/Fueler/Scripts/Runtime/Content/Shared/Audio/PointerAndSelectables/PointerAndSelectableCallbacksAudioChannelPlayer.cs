using Fueler.Content.Services.Audio;
using Fueler.Content.Shared.Audio.Channels;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Ui.SelectableCallback;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Fueler.Content.Shared.Audio.PointerAndSelectables
{
    public class PointerAndSelectableCallbacksAudioChannelPlayer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PointerCallbacks pointerCallbacks = default;
        [SerializeField] private SelectableCallbacks selectableCallbacks = default;
        [SerializeField] private AudioChannelId audioChannelId = default;

        [Header("Clips")]
        [SerializeField] private AudioClip onUpClip = default;
        [SerializeField] private AudioClip onDownClip = default;
        [SerializeField] private AudioClip onEnterSelectClip = default;
        [SerializeField] private AudioClip onExitDeselectClip = default;
        [SerializeField] private AudioClip onClickSubmitClip = default;

        [Header("Settings")]
        [SerializeField] private bool useCooldown = true;

        private void Awake()
        {
            pointerCallbacks.OnUp += OnPointerCallbacksUp;
            pointerCallbacks.OnDown += OnPointerCallbacksDown;
            pointerCallbacks.OnEnter += OnPointerCallbacksEnter;
            pointerCallbacks.OnExit += OnPointerCallbacksExit;
            pointerCallbacks.OnClick += OnPointerCallbacksClick;

            selectableCallbacks.OnSelected += OnSelectableCallbacksSelected;
            selectableCallbacks.OnDeselected += OnSelectableCallbacksDeselected;
            selectableCallbacks.OnSubmited += OnSelectableCallbacksSubmited;
        }

        private void OnDestroy()
        {
            pointerCallbacks.OnUp -= OnPointerCallbacksUp;
            pointerCallbacks.OnDown -= OnPointerCallbacksDown;
            pointerCallbacks.OnEnter -= OnPointerCallbacksEnter;
            pointerCallbacks.OnExit -= OnPointerCallbacksExit;
            pointerCallbacks.OnClick -= OnPointerCallbacksClick;

            selectableCallbacks.OnSelected -= OnSelectableCallbacksSelected;
            selectableCallbacks.OnDeselected -= OnSelectableCallbacksDeselected;
            selectableCallbacks.OnSubmited -= OnSelectableCallbacksSubmited;
        }

        private void Play(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                return;
            }

            if (!isActiveAndEnabled)
            {
                return;
            }

            bool audioServiceFound = ServiceLocator.TryGet(out IAudioService audioService);

            if (!audioServiceFound)
            {
                UnityEngine.Debug.LogError($"Tried to play audio at {nameof(AudioChannelPlayer)} but {nameof(IAudioService)} " +
                    $"could not be found on {nameof(ServiceLocator)}");
                return;
            }

            audioService.Play(audioClip, audioChannelId, useCooldown);
        }

        private void OnPointerCallbacksUp(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            Play(onUpClip);
        }

        private void OnPointerCallbacksDown(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            Play(onDownClip);
        }

        private void OnPointerCallbacksEnter(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            Play(onEnterSelectClip);
        }

        private void OnPointerCallbacksExit(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            Play(onExitDeselectClip);
        }

        private void OnPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            Play(onClickSubmitClip);
        }

        private void OnSelectableCallbacksSelected(SelectableCallbacks selectableCallbacks, BaseEventData baseEventData)
        {
            Play(onEnterSelectClip);
        }

        private void OnSelectableCallbacksDeselected(SelectableCallbacks selectableCallbacks, BaseEventData baseEventData)
        {
            Play(onExitDeselectClip);
        }

        private void OnSelectableCallbacksSubmited(SelectableCallbacks selectableCallbacks, BaseEventData baseEventData)
        {
            Play(onClickSubmitClip);
        }
    }
}
