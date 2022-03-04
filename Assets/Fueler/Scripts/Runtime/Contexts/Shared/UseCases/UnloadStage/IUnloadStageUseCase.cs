using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadStage
{
    public interface IUnloadStageUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
