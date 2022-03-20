using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Time.Data;
using Fueler.Content.Stage.Tutorial.Persistence;
using Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using Juce.Persistence.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowTimeTutorialPanel
{
    public class TryShowTimeTutorialPanelUseCase : ITryShowTimeTutorialPanelUseCase
    {
        private readonly TimeData timeData;
        private readonly SerializableData<TutorialPersistence> tutorialSerializable;
        private readonly IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase;

        public TryShowTimeTutorialPanelUseCase(
            TimeData timeData,
            SerializableData<TutorialPersistence> tutorialSerializable,
            IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase
            )
        {
            this.timeData = timeData;
            this.tutorialSerializable = tutorialSerializable;
            this.showObjectivesPopupTutorialPanelUseCase = showObjectivesPopupTutorialPanelUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            if (timeData.MaxTime <= 0)
            {
                return;
            }

            bool alreadySeen = tutorialSerializable.Data.ObjectivesPanelsSeen.Contains(ObjectiveType.Time);

            if (alreadySeen)
            {
                return;
            }

            await showObjectivesPopupTutorialPanelUseCase.Execute(ObjectiveType.Time, cancellationToken);

            tutorialSerializable.Data.ObjectivesPanelsSeen.Add(ObjectiveType.Time);

            await tutorialSerializable.Save(cancellationToken);
        }
    }
}
