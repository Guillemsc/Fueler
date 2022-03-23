using Fueler.Content.Stage.General.Data;
using Fueler.Content.Stage.General.UseCases.TryEndStage;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.Stage.Time.Data;

namespace Fueler.Content.Stage.Time.UseCases.TryEndStageIfTimeRunOut
{
    public class TryEndStageIfTimeRunOutUseCase : ITryEndStageIfTimeRunOutUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly TimeData timeData;
        private readonly ITryEndStageUseCase tryEndStageUseCase;

        public TryEndStageIfTimeRunOutUseCase(
            StageStateData stageStateData,
            TimeData timeData,
            ITryEndStageUseCase tryEndStageUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.timeData = timeData;
            this.tryEndStageUseCase = tryEndStageUseCase;
        }

        public void Execute()
        {
            if(timeData.MaxTime <= 0)
            {
                return;
            }

            if(!stageStateData.Started)
            {
                return;
            }

            if(stageStateData.Finished)
            {
                return;
            }

            if(timeData.TimeLeft > 0)
            {
                return;
            }

            tryEndStageUseCase.Execute(RanOutOfTimeLevelFinishedCause.Instance);
        }
    }
}
