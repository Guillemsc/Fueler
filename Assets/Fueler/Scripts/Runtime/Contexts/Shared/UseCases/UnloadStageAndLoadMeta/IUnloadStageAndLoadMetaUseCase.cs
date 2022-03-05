using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta
{
    public interface IUnloadStageAndLoadMetaUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
