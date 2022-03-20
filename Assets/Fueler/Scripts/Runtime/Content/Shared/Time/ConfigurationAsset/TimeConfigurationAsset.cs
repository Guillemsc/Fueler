using Fueler.Content.Shared.Time.Configuration;
using UnityEngine;

namespace Fueler.Content.Shared.Time.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "TimeConfiguration", menuName = "Fueler/Configuration/Time")]
    public class TimeConfigurationAsset : ScriptableObject
    {
        [SerializeField, Range(0f, 1f)] private float lowTimeIndicatorNormalized = 0.3f;

        public ITimeConfiguration ToConfiguration()
        {
            return new TimeConfiguration(
                lowTimeIndicatorNormalized
                );
        }
    }
}
