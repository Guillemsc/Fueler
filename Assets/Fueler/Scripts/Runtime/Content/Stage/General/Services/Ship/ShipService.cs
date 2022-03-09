using Juce.Core.Repositories;
using Fueler.Content.Stage.Ship.Entities;
using System;
using Juce.Core.Disposables;

namespace Fueler.Content.Services.Ship
{
    public class ShipService : IShipService  
    {
        public ISingleRepository<IDisposable<ShipEntity>> ShipRepository { get; }

        public ShipService(ISingleRepository<IDisposable<ShipEntity>> shipRepository)
        {
            ShipRepository = shipRepository;
        }
    }
}
