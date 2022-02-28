using Fueler.Content.Shared.Levels.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.LoadStage
{
    public interface ILoadStageUseCase
    {
        Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken);
    }
}
