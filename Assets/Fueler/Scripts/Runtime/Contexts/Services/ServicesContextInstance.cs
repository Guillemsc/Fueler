using Fueler.Content.Shared.Configuration.ConfigurationAssets;
using Juce.CoreUnity.Ui.Frame;
using UnityEngine;

namespace Fueler.Contexts.Services
{
    public class ServicesContextInstance : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] FuelerConfigurationAsset fuelerConfigurationAsset = default;

        [Header("Ui")]
        [SerializeField] private UiFrame uiFrame = default;

        public FuelerConfigurationAsset FuelerConfigurationAsset => fuelerConfigurationAsset;
        public IUiFrame UiFrame => uiFrame;
    }
}
