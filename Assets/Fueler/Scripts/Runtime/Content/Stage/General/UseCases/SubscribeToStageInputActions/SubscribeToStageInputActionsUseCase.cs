using Fueler.Assets.Fueler.Scripts.Runtime.Content.Stage.General.UseCases.RestartLevelInputPerformed;
using Fueler.Content.Shared.Input;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using static UnityEngine.InputSystem.InputAction;

namespace Fueler.Content.Stage.General.UseCases.SubscribeToStageInputActions
{
    public class SubscribeToStageInputActionsUseCase : ISubscribeToStageInputActionsUseCase
    {
        private readonly StageInputActions stageInputActions;
        private readonly IRestartLevelInputPerformedUseCase restartLevelInputPerformedUseCase;

        public SubscribeToStageInputActionsUseCase(
            StageInputActions stageInputActions,
            IRestartLevelInputPerformedUseCase restartLevelInputPerformedUseCase
            )
        {
            this.stageInputActions = stageInputActions;
            this.restartLevelInputPerformedUseCase = restartLevelInputPerformedUseCase;
        }

        public void Execute()
        {
            stageInputActions.Player.RestartLevel.performed += (CallbackContext _) => restartLevelInputPerformedUseCase.Execute();
        }
    }
}
