using Fueler.Content.Shared.Levels.UseCases.LoadNextLevel;

namespace Fueler.Content.Stage.Cheats.UseCases.NextLevel
{
    public class NextLevelUseCase : INextLevelUseCase
    {
        private readonly ILoadNextLevelUseCase loadNextLevelUseCase;

        public NextLevelUseCase(
            ILoadNextLevelUseCase loadNextLevelUseCase
            )
        {
            this.loadNextLevelUseCase = loadNextLevelUseCase;
        }

        public void Execute()
        {
            loadNextLevelUseCase.Execute();
        }
    }
}
