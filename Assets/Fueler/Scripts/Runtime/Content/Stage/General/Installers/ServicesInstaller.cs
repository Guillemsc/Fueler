using Juce.Core.DI.Builder;
using JuceUnity.Core.DI.Extensions;
using Fueler.Content.Services.Configuration;
using Juce.CoreUnity.ViewStack;
using Fueler.Content.Services.Persistence;
using Fueler.Content.Services.Ship;
using Juce.Core.Repositories;
using Juce.Core.Disposables;
using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDIContainerBuilder container)
        {
            container.Bind<IUiViewStack>().FromServicesLocator();
            container.Bind<IPersistenceService>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();

            container.Bind<IShipService, ShipService>()
                .FromFunction(c => new ShipService(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>()
                    ))
                .ToServicesLocator()
                .NonLazy();
        }
    }
}
