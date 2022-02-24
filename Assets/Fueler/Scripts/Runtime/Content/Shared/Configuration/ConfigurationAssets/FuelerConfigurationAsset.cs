using Fueler.Content.Shared.Levels.ConfigurationAssets;
using UnityEngine;

namespace Fueler.Content.Shared.Configuration.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "All", menuName = "Fueler/Configuration/All")]
    public class FuelerConfigurationAsset : ScriptableObject
    {
        [SerializeField] LevelsConfigurationAsset levelsConfigurationAsset = default;

        public LevelsConfigurationAsset LevelsConfigurationAsset => levelsConfigurationAsset;
    }
}
