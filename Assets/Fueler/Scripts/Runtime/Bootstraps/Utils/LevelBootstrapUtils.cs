using Fueler.Content.Services.Persistence;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Context.Shared.Installers;
using Fueler.Contexts.Shared;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Bootstraps.Utils
{
    public static class LevelBootstrapUtils
    {
        public static async Task Run(ILevelConfiguration levelConfiguration, CancellationToken cancellationToken)
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

            IPersistenceService persistenceService = ServiceLocator.Get<IPersistenceService>();
            await persistenceService.LoadAll(cancellationToken);

            IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase = sharedContextContainer.Resolve<IUnloadAndLoadStageUseCase>();

            await unloadAndLoadStageUseCase.Execute(levelConfiguration, isReload: false, cancellationToken);
        }
    }
}
