using UnityEngine;

namespace Fueler.Content.Shared.Audio.Channels
{
    [CreateAssetMenu(fileName = "AudioChannelId", menuName = "Fueler/Audio/ChannelId", order = 1)]
    public class AudioChannelId : ScriptableObject
    {
        [SerializeField] private string description = default;
    }
}
