using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Fuel.Configuration;
using Fueler.Content.Shared.Time.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public ILevelsConfiguration LevelsConfiguration { get; }
        public IFuelConfiguration FuelConfiguration { get; }
        public ITimeConfiguration TimeConfiguration { get; }

        public ConfigurationService(
            ILevelsConfiguration levelsConfiguration,
            IFuelConfiguration fuelConfiguration,
            ITimeConfiguration timeConfiguration
            )
        {
            LevelsConfiguration = levelsConfiguration;
            FuelConfiguration = fuelConfiguration;
            TimeConfiguration = timeConfiguration;
        }
    }
}
