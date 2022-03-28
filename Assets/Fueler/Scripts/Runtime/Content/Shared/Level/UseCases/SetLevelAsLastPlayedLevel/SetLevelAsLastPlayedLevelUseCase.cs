using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Shared.Levels.UseCases.SetLevelAsLastPlayedLevel
{
    public class SetLevelAsLastPlayedLevelUseCase : ISetLevelAsLastPlayedLevelUseCase
    {
        private readonly SerializableData<LevelsPersistence> levelsSerializable;

        public SetLevelAsLastPlayedLevelUseCase(
            SerializableData<LevelsPersistence> levelsSerializable
            )
        {
            this.levelsSerializable = levelsSerializable;
        }

        public void Execute(ILevelConfiguration levelConfiguration, bool serialize)
        {
            bool isSameLevel = levelsSerializable.Data.LastPlayedLevel == levelConfiguration.Id;

            if(isSameLevel)
            {
                return;
            }

            levelsSerializable.Data.LastPlayedLevel = levelConfiguration.Id;
            levelsSerializable.Data.LastPlayedLevelCompleted = false;

            if (serialize)
            {
                levelsSerializable.Save(CancellationToken.None).RunAsync();
            }
        }
    }
}
