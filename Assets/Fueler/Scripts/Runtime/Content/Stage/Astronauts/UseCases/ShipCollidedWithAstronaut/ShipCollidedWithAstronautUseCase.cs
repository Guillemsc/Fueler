using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.Astrounats.Entities;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;

namespace Fueler.Content.Stage.Astrounats.UseCases.ShipCollidedWithAstronaut
{
    public class ShipCollidedWithAstronautUseCase : IShipCollidedWithAstronautUseCase
    {
        private readonly AstronautsData astronautsData;
        private readonly ILevelUiInteractor levelUiInteractor;

        public ShipCollidedWithAstronautUseCase(
            AstronautsData astronautsData,
            ILevelUiInteractor levelUiInteractor
            )
        {
            this.astronautsData = astronautsData;
            this.levelUiInteractor = levelUiInteractor;
        }

        public void Execute(AstronautEntity astronautEntity)
        {
            if(astronautEntity.Collected)
            {
                return;
            }

            astronautEntity.Collected = true;

            astronautEntity.PlayCollect();

            astronautsData.CollectedAstronauts += 1;
            astronautsData.CollectedAstronauts = Mathf.Min(astronautsData.CollectedAstronauts, astronautsData.TotalAstronauts);

            levelUiInteractor.SetAstronauts(astronautsData.TotalAstronauts, astronautsData.CollectedAstronauts);
        }
    }
}
