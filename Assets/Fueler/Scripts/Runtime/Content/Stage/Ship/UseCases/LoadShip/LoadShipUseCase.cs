using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Ship.Factories;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Ship.UseCases.LoadShip
{
    public class LoadShipUseCase : ILoadShipUseCase
    {
        private readonly IFactory<ShipEntityFactoryDefinition, IDisposable<ShipEntity>> shipEntityFactory;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;

        public LoadShipUseCase(
            IFactory<ShipEntityFactoryDefinition, IDisposable<ShipEntity>> shipEntityFactory,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository
            )
        {
            this.shipEntityFactory = shipEntityFactory;
            this.shipEntityRepository = shipEntityRepository;
        }

        public bool Execute(out ShipEntity shipEntity)
        {
            if (shipEntityRepository.HasItem)
            {
                UnityEngine.Debug.LogError("There was already a ship loaded");
                shipEntity = default;
                return false;
            }

            bool created = shipEntityFactory.TryCreate(
                new ShipEntityFactoryDefinition(),
                out IDisposable<ShipEntity> loadedShipEntity
                );

            if (!created)
            {
                shipEntity = default;
                return false;
            }

            shipEntityRepository.Set(loadedShipEntity);

            shipEntity = loadedShipEntity.Value;
            return true;
        }
    }
}
