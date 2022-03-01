using Fueler.Content.Shared.Levels.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage
{
    public interface IUnloadAndLoadStageUseCase
    {
        Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken);
    }
}
