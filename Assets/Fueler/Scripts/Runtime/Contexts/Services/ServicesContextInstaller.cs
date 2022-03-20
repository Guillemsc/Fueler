using Fueler.Content.Services.Cheats.Installers;
using Fueler.Content.Services.Configuration;
using Fueler.Content.Services.Persistence;
using Fueler.Content.Services.Ship;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.ViewStack;
using JuceUnity.Core.DI.Extensions;

namespace Fueler.Contexts.Services
{
    public class ServicesContextInstaller : IContextInstaller<ServicesContextInstance>
    {
        public void Install(IDIContainerBuilder container, ServicesContextInstance instance)
        {
            container.InstallCheats();

            container.Bind<IConfigurationService>()
                .FromInstance(new ConfigurationService(
                    instance.FuelerConfigurationAsset.LevelsConfigurationAsset.ToConfiguration(),
                    instance.FuelerConfigurationAsset.FuelConfigurationAsset.ToConfiguration(),
                    instance.FuelerConfigurationAsset.TimeConfigurationAsset.ToConfiguration()
                    ))
                .ToServicesLocator()
                .NonLazy(); 

            container.Bind<IPersistenceService>()
                .FromInstance(new PersistenceService())
                .ToServicesLocator()
                .NonLazy();

            container.Bind<ITickablesService>()
                .FromInstance(instance.TickablesService)
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
