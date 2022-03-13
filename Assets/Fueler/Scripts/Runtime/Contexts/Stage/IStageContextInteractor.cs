using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage
{
    public interface IStageContextInteractor
    {
        Task Load(CancellationToken cancellationToken);
        void Start();
    }
}
