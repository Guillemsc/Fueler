using Fueler.Content.General.Configuration.Levels;
using System.Collections.Generic;
using UnityEngine;

namespace Fueler.Content.General.ConfigurationAssets.Levels
{
    [CreateAssetMenu(fileName = "LevelsConfiguration", menuName = "Fueler/Configuration/Levels")]
    public class LevelsConfigurationAsset : ScriptableObject
    {
        [SerializeField] private List<LevelConfigurationAsset> levels = new List<LevelConfigurationAsset>();

        public LevelsConfiguration ToConfiguration()
        {
            List<LevelConfiguration> levelConfigurations = new List<LevelConfiguration>();

            foreach(LevelConfigurationAsset levelAsset in levels)
            {
                levelConfigurations.Add(levelAsset.ToConfiguration());
            }

            return new LevelsConfiguration(levelConfigurations);
        }
    }
}
