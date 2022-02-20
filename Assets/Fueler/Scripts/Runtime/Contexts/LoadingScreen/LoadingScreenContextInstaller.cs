using Fueler.Content.LoadingScreen.LoadingScreenUi;
using Fueler.Context.LoadingScreen.UseCases.Show;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.CoreUnity.Contexts;

namespace Fueler.Contexts.LoadingScreen
{
    public class LoadingScreenContextInstaller : IContextInstaller<ILoadingScreenContextInteractor, LoadingScreenContextInstance>
    {
        public IDisposable<ILoadingScreenContextInteractor> Install(LoadingScreenContextInstance instance, params IDIContainer[] parentContainers)
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();
            {
                containerBuilder.Bind(parentContainers);

                containerBuilder.Bind(instance.LoadingScreenUiInstaller);

                containerBuilder.Bind<IShowUseCase>()
                    .FromFunction(c => new ShowUseCase(
                        c.Resolve<ILoadingScreenUiInteractor>()
                        ));
            }
            IDIContainer container = containerBuilder.Build();

            return new Disposable<ILoadingScreenContextInteractor>(
                new LoadingScreenContextInteractor(container.Resolve<IShowUseCase>()),
                (ILoadingScreenContextInteractor _) => { container.Dispose(); }
                );
        }
    }
}
