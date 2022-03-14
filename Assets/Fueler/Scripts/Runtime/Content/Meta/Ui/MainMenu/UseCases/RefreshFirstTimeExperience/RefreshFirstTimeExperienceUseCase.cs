using Fueler.Content.Shared.Levels.UseCases.IsFirstTimeExperience;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.RefreshFirstTimeExperience
{
    public class RefreshFirstTimeExperienceUseCase : IRefreshFirstTimeExperienceUseCase
    {
        private readonly TMPro.TextMeshProUGUI playButtonText;
        private readonly GameObject levelsButtonGameObject;
        private readonly string firstTimeExperiencePlayText;
        private readonly string nonFirstTimeExperiencePlayText;
        private readonly IIsFirstTimeExperienceUseCase isFirstTimeExperienceUseCase;

        public RefreshFirstTimeExperienceUseCase(
            TMPro.TextMeshProUGUI playButtonText,
            GameObject levelsButtonGameObject,
            string firstTimeExperiencePlayText,
            string nonFirstTimeExperiencePlayText,
            IIsFirstTimeExperienceUseCase isFirstTimeExperienceUseCase
            )
        {
            this.playButtonText = playButtonText;
            this.levelsButtonGameObject = levelsButtonGameObject;
            this.firstTimeExperiencePlayText = firstTimeExperiencePlayText;
            this.nonFirstTimeExperiencePlayText = nonFirstTimeExperiencePlayText;
            this.isFirstTimeExperienceUseCase = isFirstTimeExperienceUseCase;
        }

        public void Execute()
        {
            bool firstTime = isFirstTimeExperienceUseCase.Execute();

            if (firstTime)
            {
                levelsButtonGameObject.gameObject.SetActive(false);
                playButtonText.text = firstTimeExperiencePlayText;
            }
            else
            {
                levelsButtonGameObject.gameObject.SetActive(true);
                playButtonText.text = nonFirstTimeExperiencePlayText;
            }
        }
    }
}
