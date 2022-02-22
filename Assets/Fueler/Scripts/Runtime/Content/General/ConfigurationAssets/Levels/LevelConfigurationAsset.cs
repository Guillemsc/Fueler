using Fueler.Content.General.Configuration.Levels;
using Fueler.Content.Stage.Level.Entities;
using UnityEngine;

namespace Fueler.Content.General.ConfigurationAssets.Levels
{
    [CreateAssetMenu(fileName = "LevelsConfiguration", menuName = "Fueler/Configuration/Level")]
    public class LevelConfigurationAsset : ScriptableObject
    {
        [SerializeField] private LevelEntity levelEntityPrefab = default;

        public LevelConfiguration ToConfiguration()
        {
            return new LevelConfiguration(levelEntityPrefab);
        }
    }
}
