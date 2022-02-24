using Fueler.Content.General.UseCases.WaitUnscaledTime;
using Fueler.Content.Stage.Data;
using Fueler.Content.Stage.Level.State;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.StageUi.Ui.EndStage;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.CoreUnity.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Level.UseCases.EndLevel
{
    public class EndLevelUseCase : IEndLevelUseCase
    {
        private readonly LevelState levelState;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;
        private readonly IUiViewStack viewStack;
        private readonly IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase;

        public EndLevelUseCase(
            LevelState levelState,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository,
            IUiViewStack viewStack,
            IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase
            )
        {
            this.levelState = levelState;
            this.shipEntityRepository = shipEntityRepository;
            this.viewStack = viewStack;
            this.waitUnscaledTimeUseCase = waitUnscaledTimeUseCase;
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

            await viewStack.New().Show<IEndStageUiInteractor>(instantly: false).Execute(cancellationToken);
        }
    }
}
