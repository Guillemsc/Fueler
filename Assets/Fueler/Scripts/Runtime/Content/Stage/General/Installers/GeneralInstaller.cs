﻿using Juce.Core.DI.Builder;
using Fueler.Content.Stage.General.UseCases.LoadStage;
using Fueler.Content.Stage.General.UseCases.LoadLevel;
using Fueler.Content.Stage.Ship.UseCases.LoadShip;
using Fueler.Content.Stage.Ship.UseCases.SetShipInitialPosition;
using Fueler.Content.Stage.Ship.UseCases.SetupShipCamera;
using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.Stage.General.UseCases.StartStage;
using Fueler.Content.Stage.General.UseCases.EndStage;
using Fueler.Content.Stage.General.State;
using Juce.Core.Repositories;
using Juce.CoreUnity.ViewStack;
using Juce.Core.Disposables;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Fuel.UseCases.InitFuel;
using Fueler.Content.Stage.Astrounats.UseCases.InitAstronauts;
using Fueler.Content.Stage.Ship.UseCases.ShipCollided;
using Fueler.Content.Stage.General.UseCases.IsStageCompleted;
using Fueler.Content.Stage.General.UseCases.TryEndStage;
using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowTutorialPanels;
using Fueler.Content.Stage.General.UseCases.SubscribeToStageInputActions;
using Fueler.Content.Shared.Input;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Assets.Fueler.Scripts.Runtime.Content.Stage.General.UseCases.RestartLevelInputPerformed;
using Fueler.Content.Stage.General.Actors;

namespace Fueler.Content.Stage.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDIContainerBuilder container)
        {
            container.Bind<StageStateData>()
                .FromNew();

            container.Bind<IWaitUnscaledTimeUseCase>()
                .FromFunction(c => new WaitUnscaledTimeUseCase());

            container.Bind<ILoadStageUseCase>().FromFunction(c => new LoadStageUseCase(
                c.Resolve<StageStateData>(),
                c.Resolve<ILevelConfiguration>(),
                c.Resolve<ILoadLevelUseCase>(),
                c.Resolve<ILoadShipUseCase>(),
                c.Resolve<ISetShipInitialPositionUseCase>(),
                c.Resolve<ISetupShipCameraUseCase>(),
                c.Resolve<IShipCollidedUseCase>(),
                c.Resolve<IInitFuelUseCase>(),
                c.Resolve<IInitAstronautsUseCase>(),
                c.Resolve<IShipFuelUsedUseCase>()
                ));

            container.Bind<IStartStageUseCase>().FromFunction(c => new StartStageUseCase(
                c.Resolve<StageStateData>(),
                c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>(),
                c.Resolve<IUiViewStack>(),
                c.Resolve<IWaitUnscaledTimeUseCase>(),
                c.Resolve<ITryShowTutorialPanelsUseCase>()
                ));

            container.Bind<IIsStageCompletedUseCase>()
                .FromFunction(c => new IsStageCompletedUseCase(
                    c.Resolve<AstronautsData>()
                    ));

            container.Bind<IEndStageUseCase>().FromFunction(c => new EndStageUseCase(
                c.Resolve<LevelState>(),
                c.Resolve<ISingleRepository<IDisposable<ShipEntity>>>(),
                c.Resolve<IUiViewStack>(),
                c.Resolve<IWaitUnscaledTimeUseCase>()
                ));

            container.Bind<ITryEndStageUseCase>()
                .FromFunction(c => new TryEndStageUseCase(
                    c.Resolve<IIsStageCompletedUseCase>(),
                    c.Resolve<IEndStageUseCase>()
                    ));

            container.Bind<StageInputActions>()
                .FromNew()
                .WhenInit((c, o) => o.Enable())
                .WhenDispose(o => o.Disable());

            container.Bind<IRestartLevelInputPerformedUseCase>()
                .FromFunction(c => new RestartLevelInputPerformedUseCase(
                    c.Resolve<StageStateData>(),
                    c.Resolve<IReloadLevelUseCase>()
                    ));

            container.Bind<ISubscribeToStageInputActionsUseCase>()
                .FromFunction(c => new SubscribeToStageInputActionsUseCase(
                    c.Resolve<StageInputActions>(),
                    c.Resolve<IRestartLevelInputPerformedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();
        }
    }
}
