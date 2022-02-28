using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.General.UseCases.LoadStage;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Stage.UseCases.Load
{
    public class LoadUseCase : ILoadUseCase
    {
        private readonly ILoadStageUseCase loadStageUseCase;

        public LoadUseCase(
            ILoadStageUseCase loadStageUseCase
            )
        {
            this.loadStageUseCase = loadStageUseCase;
        }

        public Task Execute(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
        {
            return loadStageUseCase.Execute(levelConfiguration, cancellationToken);
        }
    }
}
