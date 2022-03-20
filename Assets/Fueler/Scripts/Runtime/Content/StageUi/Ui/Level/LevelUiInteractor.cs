using Fueler.Content.StageUi.Ui.Level.Enums;
using Fueler.Content.StageUi.Ui.Level.Events;
using Fueler.Content.StageUi.Ui.Level.UseCase.HideTimer;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetAstronauts;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetTimerTime;
using Fueler.Content.StageUi.Ui.Level.UseCase.ShowToasterText;
using Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowFuelIndicator;
using Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowTimeIndicator;
using System;

namespace Fueler.Content.StageUi.Ui.Level
{
    public class LevelUiInteractor : ILevelUiInteractor
    {
        private readonly LevelUiEvents levelUiEvents;
        private readonly ISetFuelUseCase setFuelUseCase;
        private readonly ITryPlayLowFuelIndicatorUseCase tryPlayLowFuelIndicatorUseCase;
        private readonly ISetAstronautsUseCase setAstronautsUseCase;
        private readonly ISetTimerTimeUseCase setTimerTimeUseCase;
        private readonly IHideTimerUseCase hideTimerUseCase;
        private readonly ITryPlayLowTimeIndicatorUseCase tryPlayLowTimeIndicatorUseCase;
        private readonly IShowToasterTextUseCase showToasterTextUseCase;

        public LevelUiInteractor(
            LevelUiEvents levelUiEvents,
            ISetFuelUseCase setFuelUseCase,
            ITryPlayLowFuelIndicatorUseCase tryPlayLowFuelIndicatorUseCase,
            ISetAstronautsUseCase setAstronautsUseCase,
            ISetTimerTimeUseCase setTimerTimeUseCase,
            IHideTimerUseCase hideTimerUseCase,
            ITryPlayLowTimeIndicatorUseCase tryPlayLowTimeIndicatorUseCase,
            IShowToasterTextUseCase showToasterTextUseCase
            )
        {
            this.levelUiEvents = levelUiEvents;
            this.setFuelUseCase = setFuelUseCase;
            this.tryPlayLowFuelIndicatorUseCase = tryPlayLowFuelIndicatorUseCase;
            this.setAstronautsUseCase = setAstronautsUseCase;
            this.setTimerTimeUseCase = setTimerTimeUseCase;
            this.hideTimerUseCase = hideTimerUseCase;
            this.tryPlayLowTimeIndicatorUseCase = tryPlayLowTimeIndicatorUseCase;
            this.showToasterTextUseCase = showToasterTextUseCase;
        }

        public void SetFuel(float maxFuel, float currentFuel)
        {
            setFuelUseCase.Execute(maxFuel, currentFuel);
        }

        public void EnableLowFuelWarning()
        {
            tryPlayLowFuelIndicatorUseCase.Execute();
        }

        public void SetAstronauts(float totalAstronauts, float currentAstronatus)
        {
            setAstronautsUseCase.Execute(totalAstronauts, currentAstronatus);
        }

        public void SetTime(int timeSeconds)
        {
            setTimerTimeUseCase.Execute(timeSeconds);
        }

        public void HideTimer()
        {
            hideTimerUseCase.Execute();
        }

        public void EnableLowTimeWarning()
        {
            tryPlayLowTimeIndicatorUseCase.Execute();
        }

        public void ShowToasterText(string text, ToasterTextDuration toasterTextDuration)
        {
            showToasterTextUseCase.Execute(text, toasterTextDuration);
        }

        public void SubscribeOnRestart(Action onRestart)
        {
            levelUiEvents.OnRestart += onRestart;
        }
    }
}
