using Juce.CoreUnity.Time;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime
{
    public class WaitUnscaledTimeUseCase : IWaitUnscaledTimeUseCase
    {
        public Task Execute(TimeSpan timeSpan, CancellationToken cancellationToken)
        {
            IUnityTimer unityTimer = new UnscaledUnityTimer();
            unityTimer.Start();

            return unityTimer.AwaitTime(timeSpan, cancellationToken);
        }
    }
}
