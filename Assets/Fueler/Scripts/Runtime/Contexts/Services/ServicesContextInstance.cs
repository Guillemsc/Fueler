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

        [Header("Ui")]
        [SerializeField] private UiFrame uiFrame = default;

        public FuelerConfigurationAsset FuelerConfigurationAsset => fuelerConfigurationAsset;
        public TickablesService TickablesService => tickablesService;
        public IUiFrame UiFrame => uiFrame;
    }
}
