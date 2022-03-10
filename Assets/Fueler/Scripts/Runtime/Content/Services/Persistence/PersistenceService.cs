using Juce.Persistence.Serialization;
using Fueler.Content.Meta.Ui.Options.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Fueler.Content.Stage.Tutorial.Persistence;
using Fueler.Content.Stage.Accessibility.Persistence;

namespace Fueler.Content.Services.Persistence
{
    public class PersistenceService : IPersistenceService
    {
        public SerializableData<GameSettingsPersistence> GameSettingsSerializable { get; }
        public SerializableData<AccessibilityPersistence> AccessibilitySerializable { get; }
        public SerializableData<TutorialPersistence> TutorialSerializable { get; }
        public SerializableData<LevelsPersistence> LevelsSerializable { get; }

        public PersistenceService()
        {
            GameSettingsSerializable = new SerializableData<GameSettingsPersistence>(GameSettingsPersistence.Path);
            AccessibilitySerializable = new SerializableData<AccessibilityPersistence>(AccessibilityPersistence.Path);
            TutorialSerializable = new SerializableData<TutorialPersistence>(TutorialPersistence.Path);
            LevelsSerializable = new SerializableData<LevelsPersistence>(LevelsPersistence.Path);
        }

        public async Task LoadAll(CancellationToken cancellationToken)
        {
            await GameSettingsSerializable.Load(cancellationToken);
            await AccessibilitySerializable.Load(cancellationToken);
            await TutorialSerializable.Load(cancellationToken);
            await LevelsSerializable.Load(cancellationToken);
        }
    }
}
