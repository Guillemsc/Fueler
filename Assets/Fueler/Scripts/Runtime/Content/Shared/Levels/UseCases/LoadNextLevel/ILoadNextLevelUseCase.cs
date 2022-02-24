using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Shared.Levels.UseCases.LoadNextLevel
{
    public interface ILoadNextLevelUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
