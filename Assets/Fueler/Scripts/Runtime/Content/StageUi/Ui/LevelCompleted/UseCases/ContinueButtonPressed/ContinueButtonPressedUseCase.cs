using Fueler.Content.Shared.Levels.UseCases.LoadNextLevel;

namespace Fueler.Content.StageUi.Ui.LevelCompleted.UseCases.ContinueButtonPressed
{
    public class ContinueButtonPressedUseCase : IContinueButtonPressedUseCase
    {
        private readonly ILoadNextLevelUseCase loadNextLevelUseCase;

        public ContinueButtonPressedUseCase(
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
