using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Content.StageUi.Ui.Level.Events;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.RestartLevelButtonPressed
{
    public class RestartLevelButtonPressedUseCase : IRestartLevelButtonPressedUseCase
    {
        private readonly LevelUiEvents levelUiEvents;

        public RestartLevelButtonPressedUseCase(
            LevelUiEvents levelUiEvents
            )
        {
            this.levelUiEvents = levelUiEvents;
        }

        public void Execute()
        {
            levelUiEvents.OnRestart?.Invoke();
        }
    }
}
