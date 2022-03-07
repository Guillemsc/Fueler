using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.Tutorial.Persistence;
using Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using Juce.Persistence.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowAstronautsTutorialPanel
{
    public class TryShowAstronautsTutorialPanelUseCase : ITryShowAstronautsTutorialPanelUseCase
    {
        private readonly AstronautsData astronautsData;
        private readonly SerializableData<TutorialPersistence> tutorialSerializable;
        private readonly IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase;

        public TryShowAstronautsTutorialPanelUseCase(
            AstronautsData astronautsData,
            SerializableData<TutorialPersistence> tutorialSerializable,
            IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase
            )
        {
            this.astronautsData = astronautsData;
            this.tutorialSerializable = tutorialSerializable;
            this.showObjectivesPopupTutorialPanelUseCase = showObjectivesPopupTutorialPanelUseCase;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            if(astronautsData.TotalAstronauts == 0)
            {
                return Task.CompletedTask;
            }

            bool alreadySeen = tutorialSerializable.Data.ObjectivesPanelsSeen.Contains(ObjectiveType.CollectAstronauts);

            if(alreadySeen)
            {
                return Task.CompletedTask;
            }

            return showObjectivesPopupTutorialPanelUseCase.Execute(ObjectiveType.CollectAstronauts, cancellationToken);
        }
    }
}
