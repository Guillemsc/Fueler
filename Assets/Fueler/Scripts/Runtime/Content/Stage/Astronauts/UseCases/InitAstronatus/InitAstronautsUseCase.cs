using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.StageUi.Ui.Level;
using UnityEngine;

namespace Fueler.Content.Stage.Astrounats.UseCases.InitAstronauts
{
    public class InitAstronautsUseCase : IInitAstronautsUseCase
    {
        private readonly AstronautsData astronautsData;
        private readonly ILevelUiInteractor levelUiInteractor;

        public InitAstronautsUseCase(
            AstronautsData astronautsData,
            ILevelUiInteractor levelUiInteractor
            )
        {
            this.astronautsData = astronautsData;
            this.levelUiInteractor = levelUiInteractor;
        }

        public void Execute(LevelEntity levelEntity)
        {
            int astronatusCount = levelEntity.Astronauts.Count;

            astronautsData.TotalAstronauts = astronatusCount;
            astronautsData.CollectedAstronauts = 0;

            levelUiInteractor.SetAstronauts(astronautsData.TotalAstronauts, astronautsData.CollectedAstronauts);
        }
    }
}
