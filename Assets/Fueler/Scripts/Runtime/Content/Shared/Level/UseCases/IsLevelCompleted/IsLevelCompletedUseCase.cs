using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System;

namespace Fueler.Content.Shared.Levels.UseCases.IsLevelCompleted
{
    public class IsLevelCompletedUseCase : IIsLevelCompletedUseCase
    {
        private readonly SerializableData<LevelsPersistence> levelsSerializable;

        public IsLevelCompletedUseCase(
            SerializableData<LevelsPersistence> levelsSerializable
            )
        {
            this.levelsSerializable = levelsSerializable;
        }

        public bool Execute(Guid levelUid)
        {
            return levelsSerializable.Data.CompletedLevels.Contains(levelUid);
        }
    }
}
