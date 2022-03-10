using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Tutorial.Persistence;
using Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using Juce.Persistence.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowFuelTutorialPanel
{
    public class TryShowFuelTutorialPanelUseCase : ITryShowFuelTutorialPanelUseCase
    {
        private readonly FuelData fuelData;
        private readonly SerializableData<TutorialPersistence> tutorialSerializable;
        private readonly IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase;

        public TryShowFuelTutorialPanelUseCase(
            FuelData fuelData,
            SerializableData<TutorialPersistence> tutorialSerializable,
            IShowObjectivesPopupTutorialPanelUseCase showObjectivesPopupTutorialPanelUseCase
            )
        {
            this.fuelData = fuelData;
            this.tutorialSerializable = tutorialSerializable;
            this.showObjectivesPopupTutorialPanelUseCase = showObjectivesPopupTutorialPanelUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            if(fuelData.MaxFuel <= 0)
            {
                return;
            }

            bool alreadySeen = tutorialSerializable.Data.ObjectivesPanelsSeen.Contains(ObjectiveType.Fuel);

            if (alreadySeen)
            {
                return;
            }

            await showObjectivesPopupTutorialPanelUseCase.Execute(ObjectiveType.Fuel, cancellationToken);

            tutorialSerializable.Data.ObjectivesPanelsSeen.Add(ObjectiveType.Fuel);

            await tutorialSerializable.Save(cancellationToken);
        }
    }
}
