using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Juce.CoreUnity.ViewStack;
using Fueler.Content.Services.Configuration;

namespace Fueler.Content.StageUi.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IConfigurationService>().FromServicesLocator();
            container.Bind<IUiViewStack>().FromServicesLocator();
        }
    }
}
