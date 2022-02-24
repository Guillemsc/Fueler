using Juce.Core.DI.Builder;
using Juce.CoreUnity.ViewStack;
using JuceUnity.Core.DI.Extensions;
using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;

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
