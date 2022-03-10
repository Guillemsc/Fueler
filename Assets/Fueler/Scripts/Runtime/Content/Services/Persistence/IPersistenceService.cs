using Juce.Persistence.Serialization;
using Fueler.Content.Meta.Ui.Options.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Fueler.Content.Stage.Tutorial.Persistence;
using Fueler.Content.Stage.Accessibility.Persistence;

namespace Fueler.Content.Services.Persistence
{
    public interface IPersistenceService
    {
        SerializableData<GameSettingsPersistence> GameSettingsSerializable { get; }
        SerializableData<AccessibilityPersistence> AccessibilitySerializable { get; }
        SerializableData<TutorialPersistence> TutorialSerializable { get; }

        Task LoadAll(CancellationToken cancellationToken);
    }
}
