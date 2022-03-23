using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadStage
{
    public interface IUnloadStageUseCase
    {
        Task Execute(bool isReload, CancellationToken cancellationToken);
    }
}
