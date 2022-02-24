using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public interface IConfigurationService
    {
        ILevelsConfiguration LevelsConfiguration { get; }
    }
}
