using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Content.Stage.General.Actors;

namespace Fueler.Assets.Fueler.Scripts.Runtime.Content.Stage.General.UseCases.RestartLevelInputPerformed
{
    public class RestartLevelInputPerformedUseCase : IRestartLevelInputPerformedUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly IReloadLevelUseCase reloadLevelUseCase;

        private bool executed;

        public RestartLevelInputPerformedUseCase(
            StageStateData stageStateData,
            IReloadLevelUseCase reloadLevelUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.reloadLevelUseCase = reloadLevelUseCase;
        }

        public void Execute()
        {
            if(!stageStateData.Started)
            {
                return;
            }

            if(executed)
            {
                return;
            }

            executed = true;

            reloadLevelUseCase.Execute();
        }
    }
}
