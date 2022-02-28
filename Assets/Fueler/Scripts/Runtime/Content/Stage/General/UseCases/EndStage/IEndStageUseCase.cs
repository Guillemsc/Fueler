using Fueler.Content.Stage.Data;

namespace Fueler.Content.Stage.General.UseCases.EndStage
{
    public interface IEndStageUseCase
    {
        void Execute(LevelEndData levelEndedData);
    }
}
