using Fueler.Content.Stage.Data;
using Fueler.Content.Stage.Level.UseCases.EndLevel;

namespace Fueler.Contexts.Stage.UseCases.End
{
    public class EndUseCase : IEndUseCase
    {
        private readonly IEndLevelUseCase endLevelUseCase;

        public EndUseCase(
            IEndLevelUseCase endLevelUseCase
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
