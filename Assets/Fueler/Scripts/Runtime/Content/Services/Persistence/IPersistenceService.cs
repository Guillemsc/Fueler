using Juce.Persistence.Serialization;
using Fueler.Content.Meta.Ui.Options.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Services.Persistence
{
    public interface IPersistenceService
    {
        SerializableData<GameSettings> GameSettingsSerializable { get; }

        Task LoadAll(CancellationToken cancellationToken);
    }
}
