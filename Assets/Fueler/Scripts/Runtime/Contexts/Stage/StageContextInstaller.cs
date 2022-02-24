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
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.Stage
{
    public class StageContextInstaller : MonoBehaviour, IContextInstaller<StageContextInstance>
    {
        public void Install(IDIContainerBuilder container, StageContextInstance instance)
        {
            container.Bind<StageContextInstance>().FromInstance(instance);

            container.InstallBase();
            container.InstallLevel();
            container.InstallShip();

            container.Bind<ILoadUseCase>()
                .FromFunction(c => new LoadUseCase(
                    c.Resolve<ILoadLevelUseCase>(),
                    c.Resolve<ILoadShipUseCase>(),
                    c.Resolve<ISetShipInitialPositionUseCase>(),
                    c.Resolve<ISetupShipCameraUseCase>()
                    ));

            container.Bind<IEndUseCase>()
                .FromFunction(c => new EndUseCase(
                    c.Resolve<IEndLevelUseCase>()
                    ));

            container.Bind<IStageContextInteractor>()
                .FromFunction(c => new StageContextInteractor(
                    c.Resolve<ILoadUseCase>(),
                    c.Resolve<IEndUseCase>()
                    ));
        }
    }
}
