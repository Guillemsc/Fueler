using Fueler.Bootstraps.Utils;
using Fueler.Content.Shared.Levels.ConfigurationAssets;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Fueler.Bootstraps
{
    public class LevelBootstrap : Bootstrap
    {
        [SerializeField] public LevelConfigurationAsset LevelConfiguration = default;

        protected override Task Run(CancellationToken cancellationToken)
        {
            return LevelBootstrapUtils.Run(LevelConfiguration.ToConfiguration(), cancellationToken);
        }
    }
}
