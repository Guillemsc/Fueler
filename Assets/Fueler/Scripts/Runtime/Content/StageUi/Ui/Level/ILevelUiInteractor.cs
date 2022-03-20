using Fueler.Content.StageUi.Ui.Level.Enums;
using System;

namespace Fueler.Content.StageUi.Ui.Level
{
    public interface ILevelUiInteractor
    {
        void SetFuel(float maxFuel, float currentFuel);
        void EnableLowFuelWarning();
        void SetAstronauts(float totalAstronauts, float currentAstronatus);
        void SetTime(int timeSeconds);
        void EnableLowTimeWarning();
        void HideTimer();
        void ShowToasterText(string text, ToasterTextDuration toasterTextDuration);
        void SubscribeOnRestart(Action onRestart);
    }
}
