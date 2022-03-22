using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Services.MetaAudio
{
    public interface IMetaAudioService
    {
        Task Play(CancellationToken cancellationToken);
        Task Stop(CancellationToken cancellationToken);
    }
}
