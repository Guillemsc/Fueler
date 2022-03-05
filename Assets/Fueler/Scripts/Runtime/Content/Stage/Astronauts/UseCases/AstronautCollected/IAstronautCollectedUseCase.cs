using Fueler.Content.Stage.Astrounats.Entities;

namespace Fueler.Content.Stage.Astrounats.UseCases.AstronautCollected
{
    public interface IAstronautCollectedUseCase
    {
        void Execute(AstronautEntity shipEntity);
    }
}
