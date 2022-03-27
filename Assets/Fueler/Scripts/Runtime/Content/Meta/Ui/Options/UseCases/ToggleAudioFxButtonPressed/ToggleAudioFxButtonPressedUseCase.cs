using Fueler.Content.Meta.Ui.Options.Persistence;
using Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioFxToggleText;
using Fueler.Contexts.Shared.UseCases.ApplyGameSettings;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Meta.Ui.Options.UseCases.ToggleAudioFxButtonPressed
{
    public class ToggleAudioFxButtonPressedUseCase : IToggleAudioFxButtonPressedUseCase
    {
        private readonly SerializableData<GameSettingsPersistence> gameSettingsSerializable;
        private readonly IApplyGameSettingsUseCase applyGameSettingsUseCase;
        private readonly IUpdateAudioFxToggleTextUseCase updateAudioFxToggleTextUseCase;

        public ToggleAudioFxButtonPressedUseCase(
            SerializableData<GameSettingsPersistence> gameSettingsSerializable,
            IApplyGameSettingsUseCase applyGameSettingsUseCase,
            IUpdateAudioFxToggleTextUseCase updateAudioFxToggleTextUseCase
            )
        {
            this.gameSettingsSerializable = gameSettingsSerializable;
            this.applyGameSettingsUseCase = applyGameSettingsUseCase;
            this.updateAudioFxToggleTextUseCase = updateAudioFxToggleTextUseCase;
        }

        public void Execute()
        {
            gameSettingsSerializable.Data.AudioFxEnabled = !gameSettingsSerializable.Data.AudioFxEnabled;

            gameSettingsSerializable.Save(CancellationToken.None).RunAsync();

            updateAudioFxToggleTextUseCase.Execute();

            applyGameSettingsUseCase.Execute();
        }
    }
}
