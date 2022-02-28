using Fueler.Content.Stage.General.UseCases.StartStage;

namespace Fueler.Contexts.Stage.UseCases.Start
{
    public class StartUseCase : IStartUseCase
    {
        private readonly IStartStageUseCase startStageUseCase;

        public StartUseCase(
            IStartStageUseCase startStageUseCase
            )
        {
            this.startStageUseCase = startStageUseCase;
        }

        public void Execute()
        {
            startStageUseCase.Execute();
        }
    }
}
