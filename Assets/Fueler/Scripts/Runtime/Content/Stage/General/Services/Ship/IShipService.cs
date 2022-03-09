using Juce.Core.Repositories;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;

namespace Fueler.Content.Services.Ship
{
    public interface IShipService
    {
        ISingleRepository<IDisposable<ShipEntity>> ShipRepository { get; }
    }
}
