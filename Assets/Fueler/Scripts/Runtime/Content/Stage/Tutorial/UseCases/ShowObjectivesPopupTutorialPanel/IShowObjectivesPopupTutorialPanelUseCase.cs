using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase
{
    public interface IShowObjectivesPopupTutorialPanelUseCase
    {
        Task Execute(ObjectiveType objectiveType, CancellationToken cancellationToken);
    }
}
