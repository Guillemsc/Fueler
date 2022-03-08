using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowTutorialPanels
{
    public interface ITryShowTutorialPanelsUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
