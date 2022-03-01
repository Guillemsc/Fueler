using Fueler.Content.Stage.Level.Data;

namespace Fueler.Content.Stage.General.UseCases.EndStage
{
    public interface IEndStageUseCase
    {
        void Execute(LevelEndData levelEndedData);
    }
}
