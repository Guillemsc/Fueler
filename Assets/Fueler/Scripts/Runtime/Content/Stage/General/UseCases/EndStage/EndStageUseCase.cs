using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.IsLastLevel;
using Fueler.Content.Shared.Levels.UseCases.SetLevelAsCompleted;
using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.Stage.General.Data;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Time.UseCases.StopTime;
using Fueler.Content.StageUi.Ui.AllLevelsCompleted;
using Fueler.Content.StageUi.Ui.LevelCompleted;
using Fueler.Content.StageUi.Ui.LevelFailed;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.CoreUnity.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.EndStage
{
    public class EndStageUseCase : IEndStageUseCase, ILevelFinishedCauseVisitor
    {
        private readonly StageStateData stageStateData;
        private readonly ILevelConfiguration levelConfiguration;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;
        private readonly IUiViewStack viewStack;
        private readonly IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase;
        private readonly IStopTimeUseCase stopTimeUseCase;
        private readonly ISetLevelAsCompletedUseCase setLevelAsCompletedUseCase;
        private readonly IIsLastLevelUseCase isLastLevelUseCase;

        public EndStageUseCase(
            StageStateData stageStateData,
            ILevelConfiguration levelConfiguration,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository,
            IUiViewStack viewStack,
            IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase,
            IStopTimeUseCase stopTimeUseCase,
            ISetLevelAsCompletedUseCase setLevelAsCompletedUseCase,
            IIsLastLevelUseCase isLastLevelUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.levelConfiguration = levelConfiguration;
            this.shipEntityRepository = shipEntityRepository;
            this.viewStack = viewStack;
            this.waitUnscaledTimeUseCase = waitUnscaledTimeUseCase;
            this.stopTimeUseCase = stopTimeUseCase;
            this.setLevelAsCompletedUseCase = setLevelAsCompletedUseCase;
            this.isLastLevelUseCase = isLastLevelUseCase;
        }

        public void Execute(ILevelFinishedCause levelFinishedCause)
        {
            if(stageStateData.Finished)
            {
                return;
            }

            stageStateData.Finished = true;

            stopTimeUseCase.Execute();

            levelFinishedCause.Accept(this);
        }

        public void Visit(ReachedEndDestinationLevelFinishedCause cause)
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if (!found)
            {
                return;
            }

            cause.LevelEndEntity.PlayCompleted();
            shipEntity.Value.ShipController.Autobreak = true;

            CompletedFlow(CancellationToken.None).RunAsync();
        }

        public void Visit(RanOutOfTimeLevelFinishedCause cause)
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if (!found)
            {
                return;
            }

            shipEntity.Value.ShipController.Autobreak = true;

            FailedFlow(CancellationToken.None).RunAsync();
        }

        public void Visit(ShipDestroyedLevelFinishedCause cause)
        {
            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if (!found)
            {
                return;
            }

            shipEntity.Value.ShipController.CanMove = false;
            shipEntity.Value.PlayDestroy();

            FailedFlow(CancellationToken.None).RunAsync();
        }

        private async Task FailedFlow(CancellationToken cancellationToken)
        {
            await waitUnscaledTimeUseCase.Execute(TimeSpan.FromSeconds(1), cancellationToken);

            await viewStack.New().Show<ILevelFailedUiInteractor>(instantly: false).Execute(cancellationToken);
        }

        private async Task CompletedFlow(CancellationToken cancellationToken)
        {
            setLevelAsCompletedUseCase.Execute(levelConfiguration);

            await waitUnscaledTimeUseCase.Execute(TimeSpan.FromSeconds(1), cancellationToken);

            bool isLastLevel = isLastLevelUseCase.Execute(levelConfiguration.Id);

            if (!isLastLevel)
            {
                await viewStack.New().Show<ILevelCompletedUiInteractor>(instantly: false).Execute(cancellationToken);
            }
            else
            {
                await viewStack.New().Show<IAllLevelsCompletedUiInteractor>(instantly: false).Execute(cancellationToken);
            }
        }
    }
}
