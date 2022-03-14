using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;

namespace Fueler.Content.Shared.Levels.UseCases.IsFirstTimeExperience
{
    public class IsFirstTimeExperienceUseCase : IIsFirstTimeExperienceUseCase
    {
        private readonly SerializableData<LevelsPersistence> levelsSerializable;

        public IsFirstTimeExperienceUseCase(
            SerializableData<LevelsPersistence> levelsSerializable
            )
        {
            this.levelsSerializable = levelsSerializable;
        }

        public bool Execute()
        {
            return levelsSerializable.Data.CompletedLevels.Count == 0;
        }
    }
}
