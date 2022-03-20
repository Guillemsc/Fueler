using Fueler.Content.Stage.Time.Data;
using Fueler.Content.Stage.Time.UseCases.TryShowLowTimeWarning;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Time.UseCases.UpdateTime
{
    public class UpdateTimeUseCase : IUpdateTimeUseCase
    {
        private readonly TimeData timeData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly ITryShowLowTimeWarningUseCase tryShowLowTimeWarningUseCase;

        public UpdateTimeUseCase(
            TimeData timeData,
            ILevelUiInteractor levelUiInteractor,
            ITryShowLowTimeWarningUseCase tryShowLowTimeWarningUseCase
            )
        {
            this.timeData = timeData;
            this.levelUiInteractor = levelUiInteractor;
            this.tryShowLowTimeWarningUseCase = tryShowLowTimeWarningUseCase;
        }

        public void Execute()
        {
            if(timeData.MaxTime <= 0)
            {
                return;
            }

            if(!timeData.Timer.Started || timeData.Timer.Paused)
            {
                return;
            }

            int timePassedSeconds = timeData.Timer.Time.Seconds;

            int timeLeft = timeData.MaxTime - timePassedSeconds;

            if(timeLeft == timeData.TimeLeft)
            {
                return;
            }

            if(timeLeft < 0)
            {
                return;
            }

            timeData.TimeLeft = timeLeft;

            levelUiInteractor.SetTime(timeData.TimeLeft);

            tryShowLowTimeWarningUseCase.Execute();
        }
    }
}
