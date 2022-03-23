using Fueler.Content.Stage.Astrounats.UseCases.TryShowNeedToCollectAllAstronatusToaster;
using Fueler.Content.Stage.General.UseCases.AreStageObjectivesCompleted;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.Level.Data;

namespace Fueler.Content.Stage.General.UseCases.TryEndStage
{
    public class TryEndStageUseCase : ITryEndStageUseCase, ILevelFinishedCauseVisitor
    {
        private readonly ITryShowNeedToCollectAllAstronatusToasterUseCase tryShowNeedToCollectAllAstronatusToasterUseCase;
        private readonly IAreStageObjectivesCompletedUseCase areStageObjectivesCompletedUseCase;
        private readonly IEndStageUseCase endStageUseCase;

        public TryEndStageUseCase(
            ITryShowNeedToCollectAllAstronatusToasterUseCase tryShowNeedToCollectAllAstronatusToasterUseCase,
            IAreStageObjectivesCompletedUseCase areStageObjectivesCompletedUseCase,
            IEndStageUseCase endStageUseCase
            )
        {
            this.tryShowNeedToCollectAllAstronatusToasterUseCase = tryShowNeedToCollectAllAstronatusToasterUseCase;
            this.areStageObjectivesCompletedUseCase = areStageObjectivesCompletedUseCase;
            this.endStageUseCase = endStageUseCase;
        }

        public void Execute(ILevelFinishedCause levelFinishedCause)
        {
            levelFinishedCause.Accept(this);
        }

        public void Visit(ReachedEndDestinationLevelFinishedCause cause)
        {
            bool isCompleted = areStageObjectivesCompletedUseCase.Execute();

            if (!isCompleted)
            {
                tryShowNeedToCollectAllAstronatusToasterUseCase.Execute();
                return;
            }

            endStageUseCase.Execute(cause);
        }

        public void Visit(RanOutOfTimeLevelFinishedCause cause)
        {
            endStageUseCase.Execute(cause);
        }

        public void Visit(ShipDestroyedLevelFinishedCause cause)
        {
            endStageUseCase.Execute(cause);
        }
    }
}
