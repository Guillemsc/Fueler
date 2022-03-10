using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.Stage.General.Actors;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowTutorialPanels;
using Fueler.Content.StageUi.Ui.Level;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.CoreUnity.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository;
        private readonly IUiViewStack uiViewStack;
        private readonly IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase;
        private readonly ITryShowTutorialPanelsUseCase tryShowTutorialPanelsUseCase;

        public StartStageUseCase(
            StageStateData stageStateData,
            ISingleRepository<IDisposable<ShipEntity>> shipEntityRepository,
            IUiViewStack uiViewStack,
            IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase,
            ITryShowTutorialPanelsUseCase tryShowTutorialPanelsUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.shipEntityRepository = shipEntityRepository;
            this.uiViewStack = uiViewStack;
            this.waitUnscaledTimeUseCase = waitUnscaledTimeUseCase;
            this.tryShowTutorialPanelsUseCase = tryShowTutorialPanelsUseCase;
        }

        public void Execute()
        {
            Run(CancellationToken.None).RunAsync();
        }

        private async Task Run(CancellationToken cancellationToken)
        {
            await waitUnscaledTimeUseCase.Execute(TimeSpan.FromSeconds(0.3f), cancellationToken);

            await tryShowTutorialPanelsUseCase.Execute(cancellationToken);

            uiViewStack.New().Show<ILevelUiInteractor>(instantly: false).Execute();

            bool shipFound = shipEntityRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if(!shipFound)
            {
                return;
            }

            shipEntity.Value.ShipController.CanMove = true;

            stageStateData.Started = true;
        }
    }
}
