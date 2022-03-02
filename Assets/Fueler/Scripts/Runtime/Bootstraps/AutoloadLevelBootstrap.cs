using Fueler.Bootstraps.Utils;
using Fueler.Content.Shared.Levels.ConfigurationAssets;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Fueler.Bootstraps
{
    public class AutoloadLevelBootstrap : Bootstrap
    {
        public const string LevelConfigurationAssetPathPlayerPrefs = "Fueler.LevelConfigurationAssetPath";

        protected override Task Run(CancellationToken cancellationToken)
        {
            bool found = TryGetLevelConfigurationAsset(out LevelConfigurationAsset levelConfigurationAsset);

            if(!found)
            {
                return Task.CompletedTask;
            }

            return LevelBootstrapUtils.Run(levelConfigurationAsset.ToConfiguration(), cancellationToken);
        }

        private static bool TryGetLevelConfigurationAsset(out LevelConfigurationAsset levelConfigurationAsset)
        {
#if UNITY_EDITOR
            bool hasKey = PlayerPrefs.HasKey(LevelConfigurationAssetPathPlayerPrefs);

            if(!hasKey)
            {
                levelConfigurationAsset = default;
                return false;
            }

            string assetPath = PlayerPrefs.GetString(LevelConfigurationAssetPathPlayerPrefs);

            levelConfigurationAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<LevelConfigurationAsset>(assetPath);
            return levelConfigurationAsset != null;

#else
             levelConfigurationAsset = default;
             return false;
#endif
        }

        public static void SetLevelConfigurationAsset(LevelConfigurationAsset levelConfigurationAsset)
        {
#if UNITY_EDITOR
            string assetPath = UnityEditor.AssetDatabase.GetAssetPath(levelConfigurationAsset);

            PlayerPrefs.SetString(LevelConfigurationAssetPathPlayerPrefs, assetPath);
#endif
        }
    }
}
