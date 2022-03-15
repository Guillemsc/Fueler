using Fueler.Content.LoadingScreen.LoadingScreenUi;
using Juce.Core.Loading;
using Juce.CoreUnity.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Context.LoadingScreen.UseCases.Show
{
    public class ShowUseCase : IShowUseCase
    {
        private readonly IUiViewStack uiViewStack;
        private readonly ILoadingScreenUiInteractor loadingScreenUiInteractor;

        public ShowUseCase(
            IUiViewStack uiViewStack,
            ILoadingScreenUiInteractor loadingScreenUiInteractor
            )
        {
            this.uiViewStack = uiViewStack;
            this.loadingScreenUiInteractor = loadingScreenUiInteractor;
        }

        public async Task<ITaskLoadingToken> Execute(CancellationToken cancellationToken)
        {
            await uiViewStack.New().CurrentSetInteractable(false).Execute(cancellationToken);

            await loadingScreenUiInteractor.SetVisible(visibe: true, cancellationToken);

            return new TaskCallbackLoadingToken(
                () => loadingScreenUiInteractor.SetVisible(visibe: false, cancellationToken)
                );
        }
    }
}
