using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Level.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage
{
    public interface IStageContextInteractor
    {
        Task Load(CancellationToken cancellationToken);
        void Start();
        void End(LevelEndData levelEndData);
    }
}
