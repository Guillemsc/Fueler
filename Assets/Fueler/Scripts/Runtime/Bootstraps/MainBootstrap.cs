using Fueler.Context.Shared.Installers;
using Fueler.Contexts.Shared;
using Fueler.Contexts.Shared.UseCases.LoadMainEntryPoint;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Bootstraps
{
    public class MainBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            IContextFactories contextFactories = ContextUtils.CreateContextFactories();

            await contextFactories.Services.Create();
            await contextFactories.Camera.Create();
            await contextFactories.LoadingScreen.Create();

            IDIContainerBuilder sharedContextBuilder = new DIContainerBuilder();
            {
                sharedContextBuilder.InstallContextShared();
            }
            IDIContainer sharedContextContainer = sharedContextBuilder.Build();

            ILoadMainEntryPointUseCase loadMainEntryPointUseCase = sharedContextContainer.Resolve<ILoadMainEntryPointUseCase>();

            await loadMainEntryPointUseCase.Execute(cancellationToken);
        }
    }
}
