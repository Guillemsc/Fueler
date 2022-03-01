using Fueler.Content.Services.Configuration;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.ViewStack;
using JuceUnity.Core.DI.Extensions;

namespace Fueler.Contexts.Services
{
    public class ServicesContextInstaller : IContextInstaller<ServicesContextInstance>
    {
        public void Install(IDIContainerBuilder container, ServicesContextInstance instance)
        {
            container.Bind<IConfigurationService>()
                .FromInstance(new ConfigurationService(
                    instance.FuelerConfigurationAsset.LevelsConfigurationAsset.ToConfiguration(),
                    instance.FuelerConfigurationAsset.FuelConfigurationAsset.ToConfiguration()
                    ))
                .ToServicesLocator()
                .NonLazy(); 

            container.Bind<IUiViewStack>()
                .FromFunction(c => new UiViewStack(
                    instance.UiFrame
                    ))
                .ToServicesLocator()
                .NonLazy();

            container.Bind<IServicesContextInteractor>()
                .FromFunction(c => new ServicesContextInteractor(
                    ));
        }
    }
}
