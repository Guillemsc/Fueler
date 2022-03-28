using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System;

namespace Fueler.Content.Shared.Levels.UseCases.GetLastPlayedLevel
{
    public class GetLastPlayedLevelUseCase : IGetLastPlayedLevelUseCase
    {
        private readonly SerializableData<LevelsPersistence> levelsSerializable;

        public GetLastPlayedLevelUseCase(
            SerializableData<LevelsPersistence> levelsSerializable
            )
        {
            this.levelsSerializable = levelsSerializable;
        }

        public Guid Execute(out bool completed)
        {
            completed = levelsSerializable.Data.LastPlayedLevelCompleted;
            return levelsSerializable.Data.LastPlayedLevel;
        }
    }
}
