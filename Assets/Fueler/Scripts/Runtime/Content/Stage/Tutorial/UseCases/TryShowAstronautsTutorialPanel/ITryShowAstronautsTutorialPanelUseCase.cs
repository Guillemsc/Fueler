using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.TryShowAstronautsTutorialPanel
{
    public interface ITryShowAstronautsTutorialPanelUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
