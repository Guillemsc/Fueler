using System;

namespace Fueler.Content.StageUi.Ui.Level
{
    public interface ILevelUiInteractor
    {
        void SetFuel(float maxFuel, float currentFuel);
        void EnableLowFuelWarning();
        void SetAstronauts(float totalAstronauts, float currentAstronatus);
        void ShowToasterText(string text);
        void SubscribeOnRestart(Action onRestart);
    }
}
