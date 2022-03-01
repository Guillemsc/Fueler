﻿using Fueler.Content.Stage.General.Actors;
using Fueler.Content.Stage.Level.Data;
using Fueler.Content.Stage.Ship.Entities;
using Fueler.Contexts.Stage;
using Juce.Core.Disposables;
using Juce.CoreUnity.Service;

namespace Fueler.Content.Stage.General.Actors
{
    public class CompleteLevelOnShipTriggerActor : ExecuteActionOnTriggerActor<ShipEntity>
    {
        protected override void OnTrigger(ShipEntity entity)
        {
            ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

            stageContext.Value.End(LevelEndData.FromCompleted());
        }
    }
}
