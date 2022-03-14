using Juce.Core.DI.Builder;
using Fueler.Content.Stage.Cheats.UseCases.AddCheats;
using Juce.Core.Repositories;
using Fueler.Content.Stage.Cheats.UseCases.DisposeCheats;
using Fueler.Content.Stage.Cheats.UseCases.SetImmortality;
using Juce.Core.Disposables;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Cheats.UseCases.GetImmortality;
using Fueler.Content.Stage.Cheats.UseCases.SetMaxFuel;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;
using Juce.Cheats.WidgetsInteractors;

namespace Fueler.Content.Stage.Cheats.Installers
{
    public static class CheatsInstaller
    {
        public static void InstallCheats(this IDIContainerBuilder container)
        {
            container.Bind<IRepository<IWidgetInteractor>>()
                .FromInstance(new SimpleRepository<IWidgetInteractor>());

            container.Bind<IAddCheatsUseCase>()
                .FromFunction(c => new AddCheatsUseCase(
                    c.Resolve<IRepository<IWidgetInteractor>>(),
                    c.Resolve<ISetImmortalityUseCase>(),
                    c.Resolve<IGetImmortalityUseCase>(),
                    c.Resolve<ISetMaxFuelUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IDisposeCheatsUseCase>()
                .FromFunction(c => new DisposeCheatsUseCase(
                    c.Resolve<IRepository<IWidgetInteractor>>()
                    ))
                .WhenDispose(o => o.Execute())
                .NonLazy();

            container.Bind<ISetImmortalityUseCase>()
                .FromFunction(c => new SetImmortalityUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>()
                    ));

            container.Bind<IGetImmortalityUseCase>()
                .FromFunction(c => new GetImmortalityUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>()
                    ));

            container.Bind<ISetMaxFuelUseCase>()
                .FromFunction(c => new SetMaxFuelUseCase(
                    c.Resolve<FuelData>(),
                    c.Resolve<IShipFuelUsedUseCase>()
                    ));
        }
    }
}
