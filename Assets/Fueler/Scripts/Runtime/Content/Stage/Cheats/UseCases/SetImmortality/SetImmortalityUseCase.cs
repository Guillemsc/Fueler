using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Cheats.UseCases.SetImmortality
{
    public class SetImmortalityUseCase : ISetImmortalityUseCase
    {
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;

        public SetImmortalityUseCase(
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository
            )
        {
            this.shipEntityRepository = shipEntityRepository;
        }

        public void Execute(bool set)
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if(!found)
            {
                return;
            }

            shipEntity.Value.Immortal = set;
        }
    }
}
