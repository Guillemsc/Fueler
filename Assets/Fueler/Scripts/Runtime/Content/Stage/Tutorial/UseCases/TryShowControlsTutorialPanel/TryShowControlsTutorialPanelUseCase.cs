using Fueler.Content.Stage.Tutorial.Persistence;
using Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using Juce.Persistence.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowControlsTutorial
{
    public class TryShowControlsTutorialPanelUseCase : ITryShowControlsTutorialPanelUseCase
    {
        private readonly SerializableData<TutorialPersistence> tutorialSerializable;
        private readonly IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase;

        public TryShowControlsTutorialPanelUseCase(
            SerializableData<TutorialPersistence> tutorialSerializable,
            IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase
            )
        {
            this.tutorialSerializable = tutorialSerializable;
            this.showObjectivesPopupTutorialPanelUseCase = showObjectivesPopupTutorialPanelUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            bool alreadySeen = tutorialSerializable.Data.ObjectivesPanelsSeen.Contains(ObjectiveType.Controls);

            if (alreadySeen)
            {
                return;
            }

            await showObjectivesPopupTutorialPanelUseCase.Execute(ObjectiveType.Controls, cancellationToken);

            tutorialSerializable.Data.ObjectivesPanelsSeen.Add(ObjectiveType.Controls);

            await tutorialSerializable.Save(cancellationToken);
        }
    }
}
