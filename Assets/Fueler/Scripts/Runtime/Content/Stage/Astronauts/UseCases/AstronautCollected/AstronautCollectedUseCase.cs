using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.Astrounats.Entities;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;

namespace Fueler.Content.Stage.Astrounats.UseCases.AstronautCollected
{
    public class AstronautCollectedUseCase : IAstronautCollectedUseCase
    {
        private readonly AstronautsData astronautsData;
        private readonly ILevelUiInteractor levelUiInteractor;

        public AstronautCollectedUseCase(
            AstronautsData astronautsData,
            ILevelUiInteractor levelUiInteractor
            )
        {
            this.astronautsData = astronautsData;
            this.levelUiInteractor = levelUiInteractor;
        }

        public void Execute(AstronautEntity shipEntity)
        {
            shipEntity.PlayCollect();

            astronautsData.CollectedAstronauts += 1;
            astronautsData.CollectedAstronauts = Mathf.Min(astronautsData.CollectedAstronauts, astronautsData.TotalAstronauts);

            levelUiInteractor.SetAstronauts(astronautsData.TotalAstronauts, astronautsData.CollectedAstronauts);
        }
    }
}
