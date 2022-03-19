using Fueler.Content.Stage.Time.Data;

namespace Fueler.Content.Stage.Time.UseCases.TryStartTime
{
    public class TryStartTimeUseCase : ITryStartTimeUseCase
    {
        private readonly TimeData timeData;

        public TryStartTimeUseCase(
            TimeData timeData
            )
        {
            this.timeData = timeData;
        }

        public void Execute()
        {
            if(timeData.MaxTime <= 0)
            {
                return;
            }

            if(timeData.Timer.Started || timeData.Timer.Paused)
            {
                return;
            }

            timeData.Timer.Start();
        }
    }
}
