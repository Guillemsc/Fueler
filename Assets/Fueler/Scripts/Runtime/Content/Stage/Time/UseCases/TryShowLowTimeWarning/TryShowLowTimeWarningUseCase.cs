using Fueler.Content.Shared.Time.Configuration;
using Fueler.Content.Stage.Time.Data;
using Fueler.Content.StageUi.Ui.Level;
using Fueler.Content.StageUi.Ui.Level.Enums;

namespace Fueler.Content.Stage.Time.UseCases.TryShowLowTimeWarning
{
    public class TryShowLowTimeWarningUseCase : ITryShowLowTimeWarningUseCase
    {
        private readonly TimeData timeData;
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly ITimeConfiguration timeConfiguration;

        public TryShowLowTimeWarningUseCase(
            TimeData timeData,
            ILevelUiInteractor levelUiInteractor,
            ITimeConfiguration timeConfiguration
            )
        {
            this.timeData = timeData;
            this.levelUiInteractor = levelUiInteractor;
            this.timeConfiguration = timeConfiguration;
        }

        public void Execute()
        {
            if (timeData.ShowedLowTimeWarning)
            {
                return;
            }

            if(timeData.MaxTime <= 0)
            {
                return;
            }

            float currentFuelNormalized = timeData.TimeLeft / (float)timeData.MaxTime;

            if (currentFuelNormalized > timeConfiguration.LowTimeIndicatorNormalized)
            {
                return;
            }

            timeData.ShowedLowTimeWarning = true;

            levelUiInteractor.ShowToasterText(
                "Low time",
                ToasterTextDuration.Short
                );

            levelUiInteractor.EnableLowTimeWarning();
        }
    }
}
