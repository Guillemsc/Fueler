using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowFuelTutorialPanel
{
    public interface ITryShowFuelTutorialPanelUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
