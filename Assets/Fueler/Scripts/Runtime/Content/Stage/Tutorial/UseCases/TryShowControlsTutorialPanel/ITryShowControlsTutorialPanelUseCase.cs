using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowControlsTutorial
{
    public interface ITryShowControlsTutorialPanelUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
