namespace Fueler.Content.Shared.Fuel.Configuration
{
    public class FuelConfiguration : IFuelConfiguration
    {
        public float FuelConsumptionRate { get; }

        public FuelConfiguration(
            float fuelConsumptionRate
            )
        {
            FuelConsumptionRate = fuelConsumptionRate;
        }
    }
}
