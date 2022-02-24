using Fueler.Content.General.UseCases.WaitUnscaledTime;
using Fueler.Content.Stage.Level.Entities;
using Fueler.Content.Stage.Level.Factories;
using Fueler.Content.Stage.Level.State;
using Fueler.Content.Stage.Level.UseCases.EndLevel;
using Fueler.Content.Stage.Level.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.ViewStack;
using JuceUnity.Core.DI.Extensions;

namespace Fueler.Content.Stage.Level.Installers
{
    public static class BaseInstaller
    {
        public static void InstallBase(this IDIContainerBuilder container)
        {
            container.Bind<IUiViewStack>().FromServicesLocator();

            container.Bind<IWaitUnscaledTimeUseCase>()
                .FromFunction(c => new WaitUnscaledTimeUseCase());
        }
    }
}
