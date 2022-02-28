using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Ship.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public ILevelsConfiguration LevelsConfiguration { get; }
        public IShipFuelConfiguration ShipFuelConfiguration { get; }

        public ConfigurationService(
            ILevelsConfiguration levelsConfiguration,
            IShipFuelConfiguration shipFuelConfiguration
            )
        {
            LevelsConfiguration = levelsConfiguration;
            ShipFuelConfiguration = shipFuelConfiguration; 
        }
    }
}
