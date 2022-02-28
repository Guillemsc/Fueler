using Fueler.Context.LoadingScreen.UseCases.Show;
using Juce.Core.Loading;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.LoadingScreen
{
    public class LoadingScreenContextInteractor : ILoadingScreenContextInteractor
    {
        private readonly IShowUseCase showUseCase;

        public LoadingScreenContextInteractor(
            IShowUseCase showUseCase
            )
        {
            this.showUseCase = showUseCase;
        }

        public Task<ITaskLoadingToken> Show(CancellationToken cancellationToken)
        {
            return showUseCase.Execute(cancellationToken);
        }
    }
}
