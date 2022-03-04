using Fueler.Content.Shared.Levels.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage
{
    public interface IUnloadMetaAndLoadStageUseCase
    {
        Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken);
    }
}
