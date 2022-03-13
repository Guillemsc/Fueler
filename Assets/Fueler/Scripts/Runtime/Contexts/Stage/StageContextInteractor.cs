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

        public StageContextInteractor(
            ILoadUseCase loadUseCase,
            IStartUseCase startUseCase
            )
        {
            this.loadUseCase = loadUseCase;
            this.startUseCase = startUseCase;
        }

        public Task Load(CancellationToken cancellationToken)
        {
            return loadUseCase.Execute(cancellationToken);
        }

        public void Start()
        {
            startUseCase.Execute();
        }
    }
}
