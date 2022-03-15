using Fueler.Assets.Fueler.Scripts.Runtime.Content.Stage.General.UseCases.RestartLevelInputPerformed;
using Fueler.Content.StageUi.Ui.Level;

namespace Fueler.Content.Stage.General.UseCases.SubscribeToStageUi
{
    public class SubscribeToStageUiUseCase : ISubscribeToStageUiUseCase
    {
        private readonly ILevelUiInteractor stageUiInteractor;
        private readonly IRestartLevelInputPerformedUseCase restartLevelInputPerformedUseCase;

        public SubscribeToStageUiUseCase(
            ILevelUiInteractor stageUiInteractor,
            IRestartLevelInputPerformedUseCase restartLevelInputPerformedUseCase
            )
        {
            this.stageUiInteractor = stageUiInteractor;
            this.restartLevelInputPerformedUseCase = restartLevelInputPerformedUseCase;
        }

        public void Execute()
        {
            stageUiInteractor.SubscribeOnRestart(restartLevelInputPerformedUseCase.Execute);
        }
    }
}
