using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.LoadMainEntryPoint
{
    public interface ILoadMainEntryPointUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
