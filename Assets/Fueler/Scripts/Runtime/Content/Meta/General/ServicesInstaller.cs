using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Juce.CoreUnity.ViewStack;
using Fueler.Content.Services.Configuration;
using Fueler.Content.Services.Persistence;

namespace Fueler.Content.Meta.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IConfigurationService>().FromServicesLocator();
            container.Bind<IPersistenceService>().FromServicesLocator();
            container.Bind<IUiViewStack>().FromServicesLocator();
        }
    }
}
