namespace Fueler.Content.Shared.Fuel.Configuration
{
    public class FuelConfiguration : IFuelConfiguration
    {
        public float FuelConsumptionRate { get; }
        public float LowFuelIndicatorNormalized { get; }

        public FuelConfiguration(
            float fuelConsumptionRate,
            float lowFuelIndicatorNormalized
            )
        {
            FuelConsumptionRate = fuelConsumptionRate;
            LowFuelIndicatorNormalized = lowFuelIndicatorNormalized;
        }
    }
}
