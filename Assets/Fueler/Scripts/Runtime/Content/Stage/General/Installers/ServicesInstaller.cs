using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Fueler.Content.Services.Configuration;
using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.Stage.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IUiViewStack>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();
        }
    }
}
