using Fueler.Content.Stage.Astrounats.Data;

namespace Fueler.Content.Stage.General.UseCases.IsStageCompleted
{
    public class IsStageCompletedUseCase : IIsStageCompletedUseCase
    {
        private readonly AstronautsData astronautsData;

        public IsStageCompletedUseCase(
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
