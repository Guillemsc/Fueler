using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.Level.Data;

namespace Fueler.Contexts.Stage.UseCases.End
{
    public class EndUseCase : IEndUseCase
    {
        private readonly IEndStageUseCase endLevelUseCase;

        public EndUseCase(
            IEndStageUseCase endLevelUseCase
            )
        {
            this.endLevelUseCase = endLevelUseCase;
        }

        public void Execute(LevelEndData levelEndData)
        {
            endLevelUseCase.Execute(levelEndData);
        }
    }
}
