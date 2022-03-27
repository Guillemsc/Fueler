using Fueler.Content.Meta.Ui.Options.Persistence;
using Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioMusicToggleText;
using Fueler.Contexts.Shared.UseCases.ApplyGameSettings;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioMusicButtonPressed
{
    public class ToggleAudioMusicButtonPressedUseCase : IToggleAudioMusicButtonPressedUseCase
    {
        private readonly SerializableData<GameSettingsPersistence> gameSettingsSerializable;
        private readonly IApplyGameSettingsUseCase applyGameSettingsUseCase;
        private readonly IUpdateAudioMusicToggleTextUseCase updateAudioMusicToggleTextUseCase;

        public ToggleAudioMusicButtonPressedUseCase(
            SerializableData<GameSettingsPersistence> gameSettingsSerializable,
            IApplyGameSettingsUseCase applyGameSettingsUseCase,
            IUpdateAudioMusicToggleTextUseCase updateAudioMusicToggleTextUseCase
            )
        {
            this.gameSettingsSerializable = gameSettingsSerializable;
            this.applyGameSettingsUseCase = applyGameSettingsUseCase;
            this.updateAudioMusicToggleTextUseCase = updateAudioMusicToggleTextUseCase;
        }

        public void Execute()
        {
            gameSettingsSerializable.Data.AudioMusicEnabled = !gameSettingsSerializable.Data.AudioMusicEnabled;

            gameSettingsSerializable.Save(CancellationToken.None).RunAsync();

            updateAudioMusicToggleTextUseCase.Execute();

            applyGameSettingsUseCase.Execute();
        }
    }
}
