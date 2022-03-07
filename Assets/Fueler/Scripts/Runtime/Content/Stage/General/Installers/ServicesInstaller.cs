using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Fueler.Content.Services.Configuration;
using Juce.CoreUnity.ViewStack;
using Fueler.Content.Services.Persistence;

namespace Fueler.Content.Stage.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IUiViewStack>().FromServicesLocator();
            container.Bind<IPersistenceService>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();
        }
    }
}
