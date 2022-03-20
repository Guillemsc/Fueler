using Fueler.Content.Shared.Levels.ConfigurationAssets;
using Fueler.Content.Shared.Fuel.ConfigurationAssets;
using UnityEngine;
using Fueler.Content.Shared.Time.ConfigurationAssets;

namespace Fueler.Content.Shared.Configuration.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "All", menuName = "Fueler/Configuration/All")]
    public class FuelerConfigurationAsset : ScriptableObject
    {
        [SerializeField] private LevelsConfigurationAsset levelsConfigurationAsset = default;
        [SerializeField] private FuelConfigurationAsset fuelConfigurationAsset = default;
        [SerializeField] private TimeConfigurationAsset timeConfigurationAsset = default;

        public LevelsConfigurationAsset LevelsConfigurationAsset => levelsConfigurationAsset;
        public FuelConfigurationAsset FuelConfigurationAsset => fuelConfigurationAsset;
        public TimeConfigurationAsset TimeConfigurationAsset => timeConfigurationAsset;
    }
}
