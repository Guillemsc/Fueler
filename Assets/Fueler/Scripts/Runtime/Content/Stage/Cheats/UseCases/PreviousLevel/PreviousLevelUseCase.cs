using Fueler.Content.Shared.Levels.UseCases.LoadPreviousLevel;

namespace Fueler.Content.Stage.Cheats.UseCases.PreviousLevel
{
    public class PreviousLevelUseCase : IPreviousLevelUseCase
    {
        private readonly ILoadPreviousLevelUseCase loadPreviousLevelUseCase;

        public PreviousLevelUseCase(
            ILoadPreviousLevelUseCase loadPreviousLevelUseCase
            )
        {
            this.loadPreviousLevelUseCase = loadPreviousLevelUseCase;
        }

        public void Execute()
        {
            loadPreviousLevelUseCase.Execute();
        }
    }
}
