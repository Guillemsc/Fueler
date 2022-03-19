using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.General.Entities;
using System;
using UnityEngine;

namespace Fueler.Content.Shared.Levels.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Fueler/Configuration/Level")]
    public class LevelConfigurationAsset : ScriptableObject
    {
        [SerializeField, TextArea] private string description = default;

        [Header("Uid")]
        [SerializeField] private string id = Guid.NewGuid().ToString();

        [Header("Setup")]
        [SerializeField] private LevelEntity levelEntityPrefab = default;

        [Header("Values")]
        [SerializeField, Min(0)] private int initialFuel = 100;
        [SerializeField, Min(0)] private int maxTime = 0;

        public ILevelConfiguration ToConfiguration()
        {
            return new LevelConfiguration(
                Guid.Parse(id), 
                levelEntityPrefab,
                initialFuel,
                maxTime
                );
        }
    }
}
