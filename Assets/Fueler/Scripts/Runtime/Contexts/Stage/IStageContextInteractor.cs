using Fueler.Content.Stage.Configuration;
using Fueler.Content.Stage.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage
{
    public interface IStageContextInteractor
    {
        Task Load(LevelConfiguration levelConfiguration, CancellationToken cancellationToken);
        void End(LevelEndData levelEndData);
    }
}
