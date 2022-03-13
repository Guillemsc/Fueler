using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.Astrounats.UseCases.TryShowNeedToCollectAllAstronatusToaster
{
    public class TryShowNeedToCollectAllAstronatusToasterUseCase : ITryShowNeedToCollectAllAstronatusToasterUseCase
    {
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly LevelMessagesData levelMessagesData;
        private readonly AstronautsData astronautsData;

        public TryShowNeedToCollectAllAstronatusToasterUseCase(
            ILevelUiInteractor levelUiInteractor,
            LevelMessagesData levelMessagesData,
            AstronautsData astronautsData
            )
        {
            this.levelUiInteractor = levelUiInteractor;
            this.levelMessagesData = levelMessagesData;
            this.astronautsData = astronautsData;
        }

        public void Execute()
        {
            if(levelMessagesData.IsNeedToCollectAllAstronatusToasterShown)
            {
                return;
            }

            if(astronautsData.TotalAstronauts <= 0)
            {
                return;
            }

            bool canShow = astronautsData.CollectedAstronauts < astronautsData.TotalAstronauts;

            if(!canShow)
            {
                return;
            }

            levelUiInteractor.ShowToasterText("Collect all the astronatus before completing the level!");
        }
    }
}
