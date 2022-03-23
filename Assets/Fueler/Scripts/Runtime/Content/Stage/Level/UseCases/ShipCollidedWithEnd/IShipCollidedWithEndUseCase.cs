using Fueler.Content.Stage.General.Entities;

namespace Fueler.Content.Stage.General.UseCases.ShipCollidedWithEnd
{
    public interface IShipCollidedWithEndUseCase
    {
        void Execute(LevelEndEntity entity);
    }
}
