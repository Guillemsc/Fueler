using Juce.Persistence.Serialization;
using Fueler.Content.Meta.Ui.Options.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Services.Persistence
{
    public class PersistenceService : IPersistenceService
    {
        public SerializableData<GameSettings> GameSettingsSerializable { get; }

        public PersistenceService()
        {
            GameSettingsSerializable = new SerializableData<GameSettings>(GameSettings.Path);
        }

        public async Task LoadAll(CancellationToken cancellationToken)
        {
            await GameSettingsSerializable.Load(cancellationToken);
        }
    }
}
