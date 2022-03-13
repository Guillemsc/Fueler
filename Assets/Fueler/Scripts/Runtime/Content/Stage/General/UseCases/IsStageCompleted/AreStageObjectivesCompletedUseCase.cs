using Fueler.Content.Stage.Astrounats.Data;

namespace Fueler.Content.Stage.General.UseCases.AreStageObjectivesCompleted
{
    public class AreStageObjectivesCompletedUseCase : IAreStageObjectivesCompletedUseCase
    {
        private readonly AstronautsData astronautsData;

        public AreStageObjectivesCompletedUseCase(
            AstronautsData astronautsData
            )
        {
            this.astronautsData = astronautsData;
        }

        public bool Execute()
        {
            if(astronautsData.TotalAstronauts > 0)
            {
                if(astronautsData.CollectedAstronauts < astronautsData.TotalAstronauts)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
