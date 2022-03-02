﻿using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Context.Shared.Installers;
using Fueler.Contexts.Shared;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
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

            IUnloadAndLoadStageUseCase unloadAndLoadStageUseCase = sharedContextContainer.Resolve<IUnloadAndLoadStageUseCase>();

            await unloadAndLoadStageUseCase.Execute(levelConfiguration, cancellationToken);
        }
    }
}