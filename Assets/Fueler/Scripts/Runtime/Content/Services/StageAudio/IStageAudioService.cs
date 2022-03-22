using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Services.StageAudio
{
    public interface IStageAudioService
    {
        Task Play(CancellationToken cancellationToken);
        Task Stop(CancellationToken cancellationToken);
    }
}
