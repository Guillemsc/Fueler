using Fueler.Content.Stage.Astrounats.Entities;

namespace Fueler.Content.Stage.Astrounats.UseCases.ShipCollidedWithAstronaut
{
    public interface IShipCollidedWithAstronautUseCase
    {
        void Execute(AstronautEntity shipEntity);
    }
}
