using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public ILevelsConfiguration LevelsConfiguration { get; }

        public ConfigurationService(
            ILevelsConfiguration levelsConfiguration
            )
        {
            LevelsConfiguration = levelsConfiguration;
        }
    }
}
