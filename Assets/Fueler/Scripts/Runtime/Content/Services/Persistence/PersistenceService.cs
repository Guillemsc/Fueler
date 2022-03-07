using Juce.Persistence.Serialization;
using Fueler.Content.Meta.Ui.Options.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Fueler.Content.Stage.Tutorial.Persistence;

namespace Fueler.Content.Services.Persistence
{
    public class PersistenceService : IPersistenceService
    {
        public SerializableData<GameSettingsPersistence> GameSettingsSerializable { get; }
        public SerializableData<TutorialPersistence> TutorialSerializable { get; }

        public PersistenceService()
        {
            GameSettingsSerializable = new SerializableData<GameSettingsPersistence>(GameSettingsPersistence.Path);
            TutorialSerializable = new SerializableData<TutorialPersistence>(TutorialPersistence.Path);
        }

        public async Task LoadAll(CancellationToken cancellationToken)
        {
            await GameSettingsSerializable.Load(cancellationToken);
            await TutorialSerializable.Load(cancellationToken);
        }
    }
}
