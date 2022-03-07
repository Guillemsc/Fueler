using Fueler.Content.Stage.General.UseCases.IsStageCompleted;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.Level.Data;

namespace Fueler.Content.Stage.General.UseCases.TryEndStage
{
    public class TryEndStageUseCase : ITryEndStageUseCase
    {
        private readonly IIsStageCompletedUseCase isStageCompletedUseCase;
        private readonly IEndStageUseCase endStageUseCase;

        public TryEndStageUseCase(
            IIsStageCompletedUseCase isStageCompletedUseCase,
            IEndStageUseCase endStageUseCase
            )
        {
            this.isStageCompletedUseCase = isStageCompletedUseCase;
            this.endStageUseCase = endStageUseCase;
        }

        public void Execute(LevelEndData levelEndedData)
        {
            if(levelEndedData.DestroyShip)
            {
                endStageUseCase.Execute(levelEndedData);
                return;
            }

            bool isCompleted = isStageCompletedUseCase.Execute();

            if(!isCompleted)
            {
                return;
            }

            endStageUseCase.Execute(levelEndedData);
        }
    }
}
