using Fueler.Content.Shared.Levels.UseCases.LoadNextLevel;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.Stage.General.State;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.Stage.Ship.Entities;
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
    public class EndStageUseCase : IEndStageUseCase
    {
        private readonly LevelState levelState;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;
        private readonly IUiViewStack viewStack;
        private readonly IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase;
        private readonly ILoadNextLevelUseCase loadNextLevelUseCase;

        public EndStageUseCase(
            LevelState levelState,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository,
            IUiViewStack viewStack,
            IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase,
            ILoadNextLevelUseCase loadNextLevelUseCase
            )
        {
            this.levelState = levelState;
            this.shipEntityRepository = shipEntityRepository;
            this.viewStack = viewStack;
            this.waitUnscaledTimeUseCase = waitUnscaledTimeUseCase;
            this.loadNextLevelUseCase = loadNextLevelUseCase;
        }

        public void Execute(LevelEndData levelEndedData)
        {
            Run(levelEndedData, CancellationToken.None).RunAsync();
        }

        private async Task Run(LevelEndData levelEndedData, CancellationToken cancellationToken)
        {
            if (levelState.Finished)
            {
                return;
            }

            levelState.Finished = true;

            bool found = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if (!found)
            {
                return;
            }

            if (levelEndedData.DestroyShip)
            {
                shipEntity.Value.ShipController.CanMove = false;
                shipEntity.Value.PlayDestroy();
            }
            else
            {
                shipEntity.Value.ShipController.Autobreak = true;
            }

            await waitUnscaledTimeUseCase.Execute(TimeSpan.FromSeconds(1), cancellationToken);

            if (levelEndedData.Completed)
            {
                await viewStack.New().Show<ILevelCompletedUiInteractor>(instantly: false).Execute(cancellationToken);

                await waitUnscaledTimeUseCase.Execute(TimeSpan.FromSeconds(1), cancellationToken);

                loadNextLevelUseCase.Execute();
            }
            else
            {
                await viewStack.New().Show<ILevelFailedUiInteractor>(instantly: false).Execute(cancellationToken);
            }
        }
    }
}
