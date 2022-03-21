using Fueler.Content.Stage.Time.Data;

namespace Fueler.Content.Stage.Time.UseCases.StopTime
{
    public class StopTimeUseCase : IStopTimeUseCase
    {
        private readonly TimeData timeData;

        public StopTimeUseCase(
            TimeData timeData
            )
        {
            this.timeData = timeData;
        }

        public void Execute()
        {
            timeData.Timer.Pause();
        }
    }
}
