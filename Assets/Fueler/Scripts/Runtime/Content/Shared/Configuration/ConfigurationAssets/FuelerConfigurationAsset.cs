using Fueler.Content.Shared.Levels.ConfigurationAssets;
using Fueler.Content.Shared.Ship.ConfigurationAssets;
using UnityEngine;

namespace Fueler.Content.Shared.Configuration.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "All", menuName = "Fueler/Configuration/All")]
    public class FuelerConfigurationAsset : ScriptableObject
    {
        [SerializeField] private LevelsConfigurationAsset levelsConfigurationAsset = default;
        [SerializeField] private ShipFuelConfigurationAsset shipFuelConfigurationAsset = default;

        public LevelsConfigurationAsset LevelsConfigurationAsset => levelsConfigurationAsset;
        public ShipFuelConfigurationAsset ShipFuelConfigurationAsset => shipFuelConfigurationAsset;
    }
}
