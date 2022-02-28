namespace Fueler.Content.Shared.Ship.Configuration
{
    public class ShipFuelConfiguration : IShipFuelConfiguration
    {
        public float FuelConsumptionRate { get; }

        public ShipFuelConfiguration(
            float fuelConsumptionRate
            )
        {
            FuelConsumptionRate = fuelConsumptionRate;
        }
    }
}
