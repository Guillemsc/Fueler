using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Data;
using Fueler.Contexts.Stage.UseCases.End;
using Fueler.Contexts.Stage.UseCases.Load;
using Fueler.Contexts.Stage.UseCases.Start;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage
{
    public class StageContextInteractor : IStageContextInteractor
    {
        private readonly ILoadUseCase loadUseCase;
        private readonly IStartUseCase startUseCase;
        private readonly IEndUseCase endUseCase;

        public StageContextInteractor(
            ILoadUseCase loadUseCase,
            IStartUseCase startUseCase,
            IEndUseCase endUseCase
            )
        {
            this.loadUseCase = loadUseCase;
            this.startUseCase = startUseCase;
            this.endUseCase = endUseCase;
        }

        public Task Load(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            return loadUseCase.Execute(levelConfiguration, cancellationToken);
        }

        public void Start()
        {
            startUseCase.Execute();
        }

        public void End(LevelEndData levelEndData)
        {
            endUseCase.Execute(levelEndData);
        }
    }
}
