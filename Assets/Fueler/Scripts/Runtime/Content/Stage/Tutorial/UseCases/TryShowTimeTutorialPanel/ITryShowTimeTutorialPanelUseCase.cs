using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowTimeTutorialPanel
{
    public interface ITryShowTimeTutorialPanelUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
