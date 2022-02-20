using Fueler.Content.LoadingScreen.LoadingScreenUi.UseCases.SetVisible;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.LoadingScreen.LoadingScreenUi
{
    public class LoadingScreenUiInteractor : ILoadingScreenUiInteractor
    {
        private readonly ISetVisibleUseCase setVisibleUseCase;

        public LoadingScreenUiInteractor(
            ISetVisibleUseCase setVisibleUseCase
            )
        {
            this.setVisibleUseCase = setVisibleUseCase;
        }

        public Task SetVisible(bool visibe, CancellationToken cancellationToken)
        {
            return setVisibleUseCase.Execute(visibe, cancellationToken);
        }
    }
}
