using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage
{
    public interface IStageContextInteractor
    {
        Task Load(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken);
        void End(LevelEndData levelEndData);
    }
}
