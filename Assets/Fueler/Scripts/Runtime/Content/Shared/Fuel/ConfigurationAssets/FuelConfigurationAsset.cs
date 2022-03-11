using Fueler.Content.Shared.Fuel.Configuration;
using UnityEngine;

namespace Fueler.Content.Shared.Fuel.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "Fuel", menuName = "Fueler/Configuration/Fuel")]
    public class FuelConfigurationAsset : ScriptableObject
    {
        [SerializeField] private float fuelConsumptionRate = default;
        [SerializeField, Range(0f, 1f)] private float lowFuelIndicatorNormalized = 0.3f;

        public IFuelConfiguration ToConfiguration()
        {
            return new FuelConfiguration(
                fuelConsumptionRate,
                lowFuelIndicatorNormalized
                );
        }
    }
}
