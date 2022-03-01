using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel;

namespace Fueler.Content.StageUi.Ui.Level
{
    public class LevelUiInteractor : ILevelUiInteractor
    {
        private readonly ISetFuelUseCase setFuelUseCase;

        public LevelUiInteractor(
            ISetFuelUseCase setFuelUseCase
            )
        {
            this.setFuelUseCase = setFuelUseCase;
        }

        public void SetFuel(float maxFuel, float currentFuel)
        {
            setFuelUseCase.Execute(maxFuel, currentFuel);
        }
    }
}
