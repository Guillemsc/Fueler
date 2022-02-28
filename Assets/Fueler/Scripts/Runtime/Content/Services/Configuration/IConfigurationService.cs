using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Ship.Configuration;

namespace Fueler.Content.Services.Configuration
{
    public interface IConfigurationService
    {
        ILevelsConfiguration LevelsConfiguration { get; }
        IShipFuelConfiguration ShipFuelConfiguration { get; }
    }
}
