using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.Stage;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.LoadStage
{
    public interface ILoadStageUseCase
    {
        Task<IStageContextInteractor> Execute(
            ILevelConfiguration levelConfiguration,
            CancellationToken cancellationToken
            );
    }
}
