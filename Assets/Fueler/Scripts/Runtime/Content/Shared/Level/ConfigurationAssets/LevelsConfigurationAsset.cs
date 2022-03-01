using Fueler.Content.Shared.Levels.Configuration;
using System.Collections.Generic;
using UnityEngine;

namespace Fueler.Content.Shared.Levels.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "LevelsConfiguration", menuName = "Fueler/Configuration/Levels")]
    public class LevelsConfigurationAsset : ScriptableObject
    {
        [SerializeField] private List<LevelConfigurationAsset> levels = new List<LevelConfigurationAsset>();

        public ILevelsConfiguration ToConfiguration()
        {
            List<ILevelConfiguration> levelConfigurations = new List<ILevelConfiguration>();

            foreach(LevelConfigurationAsset levelAsset in levels)
            {
                levelConfigurations.Add(levelAsset.ToConfiguration());
            }

            return new LevelsConfiguration(levelConfigurations);
        }
    }
}
