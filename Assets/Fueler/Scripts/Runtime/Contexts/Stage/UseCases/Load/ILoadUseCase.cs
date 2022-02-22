using Fueler.Content.General.Configuration.Levels;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage.UseCases.Load
{
    public interface ILoadUseCase
    {
        Task Execute(LevelConfiguration levelConfiguration, CancellationToken cancellationToken);
    }
}
