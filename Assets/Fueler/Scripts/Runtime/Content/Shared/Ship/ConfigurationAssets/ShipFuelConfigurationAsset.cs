using Fueler.Content.Shared.Ship.Configuration;
using System;
using UnityEngine;

namespace Fueler.Content.Shared.Ship.ConfigurationAssets
{
    [CreateAssetMenu(fileName = "ShipFuel", menuName = "Fueler/Configuration/ShipFuel")]
    public class ShipFuelConfigurationAsset : ScriptableObject
    {
        [SerializeField] private float fuelConsumptionRate;

        public IShipFuelConfiguration ToConfiguration()
        {
            return new ShipFuelConfiguration(fuelConsumptionRate);
        }
    }
}
