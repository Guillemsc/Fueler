using Fueler.Content.Shared.Levels.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage.UseCases.Load
{
    public interface ILoadUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
