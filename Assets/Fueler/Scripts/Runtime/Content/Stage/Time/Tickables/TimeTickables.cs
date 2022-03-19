using Fueler.Content.Stage.Time.UseCases.TryEndStageIfTimeRunOut;
using Fueler.Content.Stage.Time.UseCases.UpdateTime;
using Juce.Core.Tickable;

namespace Fueler.Content.Stage.Time.Tickables.UpdateTime
{
    public class TimeTickables : ITickable
    {
        private readonly IUpdateTimeUseCase updateTimeUseCase;
        private readonly ITryEndStageIfTimeRunOutUseCase tryEndStageIfTimeRunOutUseCase;

        public TimeTickables(
            IUpdateTimeUseCase updateTimeUseCase,
            ITryEndStageIfTimeRunOutUseCase tryEndStageIfTimeRunOutUseCase
            )
        {
            this.updateTimeUseCase = updateTimeUseCase;
            this.tryEndStageIfTimeRunOutUseCase = tryEndStageIfTimeRunOutUseCase;
        }

        public void Tick()
        {
            updateTimeUseCase.Execute();
            tryEndStageIfTimeRunOutUseCase.Execute();
        }
    }
}
