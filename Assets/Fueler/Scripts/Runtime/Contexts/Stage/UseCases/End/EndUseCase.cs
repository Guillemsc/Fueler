using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.General.UseCases.TryEndStage;
using Fueler.Content.Stage.Level.Data;

namespace Fueler.Contexts.Stage.UseCases.End
{
    public class EndUseCase : IEndUseCase
    {
        private readonly ITryEndStageUseCase tryEndStageUseCase;

        public EndUseCase(
            ITryEndStageUseCase tryEndStageUseCase
            )
        {
            this.tryEndStageUseCase = tryEndStageUseCase;
        }

        public void Execute(LevelEndData levelEndData)
        {
            tryEndStageUseCase.Execute(levelEndData);
        }
    }
}
