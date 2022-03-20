using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Fuel.Configuration;
using Fueler.Content.Shared.Time.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public interface IConfigurationService
    {
        ILevelsConfiguration LevelsConfiguration { get; }
        IFuelConfiguration FuelConfiguration { get; }
        ITimeConfiguration TimeConfiguration { get; }
    }
}
