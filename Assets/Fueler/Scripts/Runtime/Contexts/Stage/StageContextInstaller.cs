using Fueler.Content.Stage.General.Installers;
using Fueler.Content.Stage.General.UseCases.LoadStage;
using Fueler.Content.Stage.Ship.Installers;
using Fueler.Contexts.Stage.UseCases.End;
using Fueler.Contexts.Stage.UseCases.Load;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using Fueler.Contexts.Stage.UseCases.Start;
using Fueler.Content.Stage.General.UseCases.StartStage;
using Fueler.Content.Stage.Fuel.Installers;
using Fueler.Context.Shared.Installers;
using Fueler.Content.Stage.Astrounats.Installers;
using Fueler.Content.Stage.Cheats.Installers;
using Fueler.Content.Stage.Tutorial.Installers;
using Fueler.Content.Stage.General.UseCases.TryEndStage;
using Fueler.Content.Stage.Accessibility.Installers;

namespace Fueler.Contexts.Stage
{
    public class StageContextInstaller : IContextInstaller<StageContextInstance>
    {
        public void Install(IDIContainerBuilder container, StageContextInstance instance)
        {
            container.Bind<StageContextInstance>().FromInstance(instance);

            container.InstallContextShared();
            container.InstallServices();
            container.InstallGeneral();
            container.InstallCheats();
            container.InstallAccessibility();
            container.InstallLevel();
            container.InstallShip();
            container.InstallFuel();
            container.InstallAstronauts();
            container.InstallTutorial();

            container.Bind<ILoadUseCase>()
                .FromFunction(c => new LoadUseCase(
                    c.Resolve<ILoadStageUseCase>()
                    ));

            container.Bind<IStartUseCase>()
                .FromFunction(c => new StartUseCase(
                    c.Resolve<IStartStageUseCase>()
                    ));

            container.Bind<IEndUseCase>()
                .FromFunction(c => new EndUseCase(
                    c.Resolve<ITryEndStageUseCase>()
                    ));

            container.Bind<IStageContextInteractor>()
                .FromFunction(c => new StageContextInteractor(
                    c.Resolve<ILoadUseCase>(),
                    c.Resolve<IStartUseCase>()
                    ));
        }
    }
}
