using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Fueler.Content.Services.Configuration;

namespace Fueler.Content.Stage.Level.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IConfigurationService>().FromServicesLocator();
        }
    }
}
