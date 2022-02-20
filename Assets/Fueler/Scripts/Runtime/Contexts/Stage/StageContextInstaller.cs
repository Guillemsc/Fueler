using Fueler.Content.Stage.Level.Installers;
using Fueler.Content.Stage.Level.UseCases.EndLevel;
using Fueler.Content.Stage.Level.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.Installers;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
using Fueler.Contexts.Stage.UseCases.End;
using Fueler.Contexts.Stage.UseCases.Load;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.CoreUnity.Contexts;

namespace Fueler.Contexts.Stage
{
    public class StageContextInstaller : IContextInstaller<IStageContextInteractor, StageContextInstance>
    {
        public IDisposable<IStageContextInteractor> Install(StageContextInstance instance, params IDIContainer[] parentContainers)
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();
            {
                containerBuilder.Bind(parentContainers);

                containerBuilder.Bind<StageContextInstance>().FromInstance(instance);

                containerBuilder.InstallLevel();
                containerBuilder.InstallShip();

                containerBuilder.Bind<ILoadUseCase>()
                    .FromFunction(c => new LoadUseCase(
                        c.Resolve<ILoadLevelUseCase>(),
                        c.Resolve<ILoadShipUseCase>(),
                        c.Resolve<ISetShipInitialPositionUseCase>(),
                        c.Resolve<ISetupShipCameraUseCase>()
                        ));

                containerBuilder.Bind<IEndUseCase>()
                    .FromFunction(c => new EndUseCase(
                        c.Resolve<IEndLevelUseCase>()
                        ));
            }
            IDIContainer container = containerBuilder.Build();

            IStageContextInteractor interactor = new StageContextInteractor(
                container.Resolve<ILoadUseCase>(),
                container.Resolve<IEndUseCase>()
                );

            return new Disposable<IStageContextInteractor>(interactor, (IStageContextInteractor _) => { });
        }
    }
}
