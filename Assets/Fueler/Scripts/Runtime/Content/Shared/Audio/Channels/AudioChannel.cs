﻿using UnityEngine;

namespace Fueler.Content.Shared.Audio.Channels
{
    [System.Serializable]
    public class AudioChannel 
    {
        [Header("References")]
        [SerializeField] private AudioChannelId audioChannelId = default;
        [SerializeField] private AudioSource audioSource = default;

        [Header("Values")]
        [SerializeField] private float volume = 0.6f;
        [SerializeField, Min(0)] private float cooldown = 0.02f;
        [SerializeField] private bool allowMultipleSimultaneous = true;

        public AudioChannelId AudioChannelId => audioChannelId;
        public AudioSource AudioSource => audioSource;

        public float Volume => volume;
        public float Cooldown => cooldown;
        public bool AllowMultipleSimultaneous => allowMultipleSimultaneous;
    }
}
