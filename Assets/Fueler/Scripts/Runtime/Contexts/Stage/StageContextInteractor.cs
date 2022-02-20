using Fueler.Content.Stage.Configuration;
using Fueler.Content.Stage.Data;
using Fueler.Contexts.Stage.UseCases.End;
using Fueler.Contexts.Stage.UseCases.Load;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage
{
    public class StageContextInteractor : IStageContextInteractor
    {
        private readonly ILoadUseCase loadUseCase;
        private readonly IEndUseCase endUseCase;

        public StageContextInteractor(
            ILoadUseCase loadUseCase,
            IEndUseCase endUseCase
            )
        {
            this.loadUseCase = loadUseCase;
            this.endUseCase = endUseCase;
        }

        public Task Load(LevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            return loadUseCase.Execute(levelConfiguration, cancellationToken);
        }

        public void End(LevelEndData levelEndData)
        {
            endUseCase.Execute(levelEndData);
        }
    }
}
