using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Level.Entities;
using System;
using UnityEngine;

namespace Fueler.Content.Shared.Levels.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "LevelsConfiguration", menuName = "Fueler/Configuration/Level")]
    public class LevelConfigurationAsset : ScriptableObject
    {
        [SerializeField] private string id = Guid.NewGuid().ToString();
        [SerializeField] private LevelEntity levelEntityPrefab = default;

        public ILevelConfiguration ToConfiguration()
        {
            return new LevelConfiguration(Guid.Parse(id), levelEntityPrefab);
        }
    }
}
