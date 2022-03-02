using Fueler.Content.Meta.Ui.MainMenu;
using Fueler.Content.Meta.Ui.SplashScreen;
using Fueler.Contexts.LoadingScreen;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.LoadMainEntryPoint
{
    public class LoadMainEntryPointUseCase : ILoadMainEntryPointUseCase
    {
        public async Task Execute(CancellationToken cancellationToken)
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            IContextFactories contextFactories = ServiceLocator.Get<IContextFactories>();

            await contextFactories.Meta.Create();

            IUiViewStack viewStack = ServiceLocator.Get<IUiViewStack>();

            await loadingToken.Complete();

            await viewStack.New()
                .Show<ISplashScreenUiInteractor>(instantly: false)
                .Hide<ISplashScreenUiInteractor>(instantly: false)
                .Show<IMainMenuUiInteractor>(instantly: false)
                .Execute(cancellationToken);
        }
    }
}
