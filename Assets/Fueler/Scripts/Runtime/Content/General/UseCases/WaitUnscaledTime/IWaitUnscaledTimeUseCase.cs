using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.General.UseCases.WaitUnscaledTime
{
    public interface IWaitUnscaledTimeUseCase
    {
        Task Execute(TimeSpan timeSpan, CancellationToken cancellationToken);
    }
}
