using Fueler.Content.Meta.Ui.Options.Persistence;
using Juce.Persistence.Serialization;

namespace Fueler.Content.Meta.Ui.Options.UseCases.AudioOnOffButtonPressed
{
    public class AudioOnOffButtonPressedUseCase : IAudioOnOffButtonPressedUseCase
    {
        private readonly SerializableData<GameSettingsPersistence> gameSettingsSerializable;

        public AudioOnOffButtonPressedUseCase(
            SerializableData<GameSettingsPersistence> gameSettingsSerializable
            )
        {
            this.gameSettingsSerializable = gameSettingsSerializable;
        }

        public void Execute()
        {

        }
    }
}
