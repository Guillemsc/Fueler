namespace Fueler.Content.Shared.Time.Configuration
{
    public class TimeConfiguration : ITimeConfiguration
    {
        public float LowTimeIndicatorNormalized { get; }

        public TimeConfiguration(
            float lowTimeIndicatorNormalized
            )
        {
            LowTimeIndicatorNormalized = lowTimeIndicatorNormalized;
        }
    }
}