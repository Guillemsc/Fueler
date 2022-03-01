using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Fuel.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public ILevelsConfiguration LevelsConfiguration { get; }
        public IFuelConfiguration FuelConfiguration { get; }

        public ConfigurationService(
            ILevelsConfiguration levelsConfiguration,
            IFuelConfiguration fuelConfiguration
            )
        {
            LevelsConfiguration = levelsConfiguration;
            FuelConfiguration = fuelConfiguration; 
        }
    }
}
