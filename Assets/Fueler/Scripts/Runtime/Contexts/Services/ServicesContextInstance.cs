using Fueler.Content.Services.Audio;
using Fueler.Content.Services.MetaAudio;
using Fueler.Content.Services.StageAudio;
using Fueler.Content.Shared.Configuration.ConfigurationAssets;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Ui.Frame;
using UnityEngine;

namespace Fueler.Contexts.Services
{
    public class ServicesContextInstance : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private FuelerConfigurationAsset fuelerConfigurationAsset = default;

        [Header("Tickables")]
        [SerializeField] private TickablesService tickablesService = default;

        [Header("Audio")]
        [SerializeField] private AudioService audioService = default;
        [SerializeField] private MetaAudioService metaAudioService = default;
        [SerializeField] private StageAudioService stageAudioService = default;

        [Header("Ui")]
        [SerializeField] private UiFrame uiFrame = default;

        public FuelerConfigurationAsset FuelerConfigurationAsset => fuelerConfigurationAsset;
        public TickablesService TickablesService => tickablesService;
        public AudioService AudioService => audioService;
        public MetaAudioService MetaAudioService => metaAudioService;
        public StageAudioService StageAudioService => stageAudioService;
        public IUiFrame UiFrame => uiFrame;
    }
}
