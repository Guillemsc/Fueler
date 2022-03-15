using Fueler.Content.StageUi.Ui.Level.Events;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetAstronauts;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel;
using Fueler.Content.StageUi.Ui.Level.UseCase.ShowToasterText;
using Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowFuelIndicator;
using System;

namespace Fueler.Content.StageUi.Ui.Level
{
    public class LevelUiInteractor : ILevelUiInteractor
    {
        private readonly LevelUiEvents levelUiEvents;
        private readonly ISetFuelUseCase setFuelUseCase;
        private readonly ITryPlayLowFuelIndicatorUseCase tryPlayLowFuelIndicatorUseCase;
        private readonly ISetAstronautsUseCase setAstronautsUseCase;
        private readonly IShowToasterTextUseCase showToasterTextUseCase;

        public LevelUiInteractor(
            LevelUiEvents levelUiEvents,
            ISetFuelUseCase setFuelUseCase,
            ITryPlayLowFuelIndicatorUseCase tryPlayLowFuelIndicatorUseCase,
            ISetAstronautsUseCase setAstronautsUseCase,
            IShowToasterTextUseCase showToasterTextUseCase
            )
        {
            this.levelUiEvents = levelUiEvents;
            this.setFuelUseCase = setFuelUseCase;
            this.tryPlayLowFuelIndicatorUseCase = tryPlayLowFuelIndicatorUseCase;
            this.setAstronautsUseCase = setAstronautsUseCase;
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

        public void ShowToasterText(string text)
        {
            showToasterTextUseCase.Execute(text);
        }

        public void SubscribeOnRestart(Action onRestart)
        {
            levelUiEvents.OnRestart += onRestart;
        }
    }
}
