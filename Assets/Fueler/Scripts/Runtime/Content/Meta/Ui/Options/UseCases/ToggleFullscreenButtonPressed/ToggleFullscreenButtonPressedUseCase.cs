using Fueler.Content.Meta.Ui.Options.Persistence;
using Fueler.Contexts.Shared.UseCases.ApplyGameSettings;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Meta.Ui.Options.UseCases.ToggleFullscreenButtonPressed
{
    public class ToggleFullscreenButtonPressedUseCase : IToggleFullscreenButtonPressedUseCase
    {
        private readonly SerializableData<GameSettingsPersistence> gameSettingsSerializable;
        private readonly IApplyGameSettingsUseCase applyGameSettingsUseCase;

        public ToggleFullscreenButtonPressedUseCase(
            SerializableData<GameSettingsPersistence> gameSettingsSerializable,
            IApplyGameSettingsUseCase applyGameSettingsUseCase
            )
        {
            this.gameSettingsSerializable = gameSettingsSerializable;
            this.applyGameSettingsUseCase = applyGameSettingsUseCase;
        }

        public void Execute()
        {
            gameSettingsSerializable.Data.Fullscreen = !gameSettingsSerializable.Data.Fullscreen;

            gameSettingsSerializable.Save(CancellationToken.None).RunAsync();

            applyGameSettingsUseCase.Execute();
        }
    }
}
