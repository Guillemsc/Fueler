using Fueler.Content.Stage.Level.Data;

namespace Fueler.Content.Stage.General.UseCases.TryEndStage
{
    public interface ITryEndStageUseCase
    {
        void Execute(LevelEndData levelEndedData);
    }
}
