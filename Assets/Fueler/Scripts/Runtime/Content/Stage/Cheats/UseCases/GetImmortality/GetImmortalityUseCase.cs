using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Cheats.UseCases.GetImmortality
{
    public class GetImmortalityUseCase : IGetImmortalityUseCase
    {
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;

        public GetImmortalityUseCase(
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository
            )
        {
            this.shipEntityRepository = shipEntityRepository;
        }

        public bool Execute()
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if (!found)
            {
                return false;
            }

            return shipEntity.Value.Immortal;
        }
    }
}
