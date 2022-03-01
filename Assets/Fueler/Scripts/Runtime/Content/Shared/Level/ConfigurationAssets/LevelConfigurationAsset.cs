using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.General.Entities;
using System;
using UnityEngine;

namespace Fueler.Content.Shared.Levels.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Fueler/Configuration/Level")]
    public class LevelConfigurationAsset : ScriptableObject
    {
        [Header("Uid")]
        [SerializeField] private string id = Guid.NewGuid().ToString();

        [Header("Setup")]
        [SerializeField] private LevelEntity levelEntityPrefab = default;

        [Header("Values")]
        [SerializeField, Min(0)] private int initialFuel = 100;

        public ILevelConfiguration ToConfiguration()
        {
            return new LevelConfiguration(
                Guid.Parse(id), 
                levelEntityPrefab,
                initialFuel
                );
        }
    }
}
