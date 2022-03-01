using Fueler.Content.Shared.Fuel.Configuration;
using System;
using UnityEngine;

namespace Fueler.Content.Shared.Fuel.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "Fuel", menuName = "Fueler/Configuration/Fuel")]
    public class FuelConfigurationAsset : ScriptableObject
    {
        [SerializeField] private float fuelConsumptionRate;

        public IFuelConfiguration ToConfiguration()
        {
            return new FuelConfiguration(fuelConsumptionRate);
        }
    }
}
