using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Time.Data;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Time.UseCases.InitTime
{
    public class InitTimeUseCase : IInitTimeUseCase
    {
        private readonly TimeData timeData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly ILevelConfiguration levelConfiguration;

        public InitTimeUseCase(
            TimeData timeData,
            ILevelUiInteractor levelUiInteractor,
            ILevelConfiguration levelConfiguration
            )
        {
            this.timeData = timeData;
            this.levelUiInteractor = levelUiInteractor;
            this.levelConfiguration = levelConfiguration;
        }

        public void Execute()
        {
            timeData.MaxTime = levelConfiguration.MaxTime;
            timeData.TimeLeft = timeData.MaxTime;

            if(timeData.MaxTime <= 0)
            {
                levelUiInteractor.HideTimer();
                return;
            }

            levelUiInteractor.SetTime(timeData.MaxTime);
        }
    }
}
