﻿using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Shared.Levels.UseCases.SetLevelAsCompleted
{
    public class SetLevelAsCompletedUseCase : ISetLevelAsCompletedUseCase
    {
        private readonly SerializableData<LevelsPersistence> levelsSerializable;

        public SetLevelAsCompletedUseCase(
            SerializableData<LevelsPersistence> levelsSerializable
            )
        {
            this.levelsSerializable = levelsSerializable;
        }

        public void Execute(ILevelConfiguration levelConfiguration, bool serialize)
        {
            bool alreadyAdded = levelsSerializable.Data.CompletedLevels.Contains(levelConfiguration.Id);

            if(alreadyAdded)
            {
                return;
            }

            levelsSerializable.Data.CompletedLevels.Add(levelConfiguration.Id);

            bool isLastPlayedLevel = levelsSerializable.Data.LastPlayedLevel == levelConfiguration.Id;

            if (isLastPlayedLevel)
            {
                levelsSerializable.Data.LastPlayedLevelCompleted = true;
            }

            if (serialize)
            {
                levelsSerializable.Save(CancellationToken.None).RunAsync();
            }
        }
    }
}
