using Fueler.Content.StageUi.Ui.Level.UseCase.SetAstronauts;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel;

namespace Fueler.Content.StageUi.Ui.Level
{
    public class LevelUiInteractor : ILevelUiInteractor
    {
        private readonly ISetFuelUseCase setFuelUseCase;
        private readonly ISetAstronautsUseCase setAstronautsUseCase;

        public LevelUiInteractor(
            ISetFuelUseCase setFuelUseCase,
            ISetAstronautsUseCase setAstronautsUseCase
            )
        {
            this.setFuelUseCase = setFuelUseCase;
            this.setAstronautsUseCase = setAstronautsUseCase;
        }

        public void SetFuel(float maxFuel, float currentFuel)
        {
            setFuelUseCase.Execute(maxFuel, currentFuel);
        }

        public void SetAstronauts(float totalAstronauts, float currentAstronatus)
        {
            setAstronautsUseCase.Execute(totalAstronauts, currentAstronatus);
        }
    }
}
