using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Content.Stage.General.Data;

namespace Fueler.Assets.Fueler.Scripts.Runtime.Content.Stage.General.UseCases.RestartLevelInputPerformed
{
    public class RestartLevelInputPerformedUseCase : IRestartLevelInputPerformedUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly IReloadLevelUseCase reloadLevelUseCase;

        public RestartLevelInputPerformedUseCase(
            StageStateData stageStateData,
            IReloadLevelUseCase reloadLevelUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.stageStateData = stageStateData;
            this.reloadLevelUseCase = reloadLevelUseCase;
        }

        public void Execute()
        {
            if(stageStateData.Finished)
            {
                return;
            }

            if(!stageStateData.Started)
            {
                return;
            }

            stageStateData.Finished = true;

            reloadLevelUseCase.Execute();
        }
    }
}
