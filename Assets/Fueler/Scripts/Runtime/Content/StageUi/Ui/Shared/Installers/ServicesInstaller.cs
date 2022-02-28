using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Juce.CoreUnity.ViewStack;

namespace Fueler.Content.StageUi.Shared.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IUiViewStack>().FromServicesLocator();
        }
    }
}
