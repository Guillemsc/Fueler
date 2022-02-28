using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuelLeftNormalized;

namespace Fueler.Content.StageUi.Ui.Level
{
    public class LevelUiInteractor : ILevelUiInteractor
    {
        private readonly ISetFuelLeftNormalizedUseCase setFuelLeftNormalizedUseCase;

        public LevelUiInteractor(
            ISetFuelLeftNormalizedUseCase setFuelLeftNormalizedUseCase
            )
        {
            this.setFuelLeftNormalizedUseCase = setFuelLeftNormalizedUseCase;
        }

        public void SetFuelNormalized(float fuelNormalized)
        {
            setFuelLeftNormalizedUseCase.Execute(fuelNormalized);
        }
    }
}
