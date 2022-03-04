using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;

namespace Fueler.Content.Meta.Ui.LevelFailed.UseCases.TryAgainButtonPressed
{
    public class TryAgainButtonPressedUseCase : ITryAgainButtonPressedUseCase
    {
        private readonly IReloadLevelUseCase reloadLevelUseCase;

        public TryAgainButtonPressedUseCase(
            IReloadLevelUseCase reloadLevelUseCase
            )
        {
            this.reloadLevelUseCase = reloadLevelUseCase;
        }

        public void Execute()
        {
            reloadLevelUseCase.Execute();
        }
    }
}
