using Fueler.Content.Meta.Ui.Options.Persistence;
using Juce.Persistence.Serialization;

namespace Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioMusicToggleText
{
    public class UpdateAudioMusicToggleTextUseCase : IUpdateAudioMusicToggleTextUseCase
    {
        private readonly SerializableData<GameSettingsPersistence> gameSettingsSerializable;
        private readonly TMPro.TextMeshProUGUI text;
        private readonly string enabledText;
        private readonly string disabledText;

        public UpdateAudioMusicToggleTextUseCase(
            SerializableData<GameSettingsPersistence> gameSettingsSerializable,
            TMPro.TextMeshProUGUI text,
            string enabledText,
            string disabledText
            )
        {
            this.gameSettingsSerializable = gameSettingsSerializable;
            this.text = text;
            this.enabledText = enabledText;
            this.disabledText = disabledText;
        }

        public void Execute()
        {
            text.text = gameSettingsSerializable.Data.AudioMusicEnabled ?
                enabledText : disabledText;
        }
    }
}
