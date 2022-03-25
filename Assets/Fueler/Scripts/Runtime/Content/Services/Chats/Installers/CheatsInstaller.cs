using Juce.Core.DI.Builder;
using Juce.Core.Repositories;
using Juce.Cheats.WidgetsInteractors;
using Fueler.Content.Services.Cheats.UseCases.AddCheats;
using Fueler.Content.Services.Cheats.UseCases.ClearAllUserData;
using Fueler.Content.Services.Cheats.UseCases.UnlockAllLevels;
using Fueler.Content.Services.Configuration;
using Fueler.Content.Services.Persistence;

namespace Fueler.Content.Services.Cheats.Installers
{
    public static class CheatsInstaller
    {
        public static void InstallCheats(this IDIContainerBuilder container)
        {
            container.Bind<IRepository<IWidgetInteractor>>()
                .FromInstance(new SimpleRepository<IWidgetInteractor>());

            container.Bind<IAddCheatsUseCase>()
                .FromFunction(c => new AddCheatsUseCase(
                    c.Resolve<IClearAllUserDataUseCase>(),
                    c.Resolve<IUnlockAllLevelsUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IClearAllUserDataUseCase>()
                .FromFunction(c => new ClearAllUserDataUseCase(
                ));

            container.Bind<IUnlockAllLevelsUseCase>()
                .FromFunction(c => new UnlockAllLevelsUseCase(
                    c.Resolve<IConfigurationService>(),
                    c.Resolve<IPersistenceService>()
                    ));
        }
    }
}
