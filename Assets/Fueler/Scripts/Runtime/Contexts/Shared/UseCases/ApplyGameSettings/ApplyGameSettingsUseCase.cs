using Fueler.Content.Meta.Ui.Options.Persistence;
using Fueler.Content.Services.Audio;
using Fueler.Content.Services.Persistence;
using Juce.CoreUnity.Service;
using UnityEngine;

namespace Fueler.Contexts.Shared.UseCases.ApplyGameSettings
{
    public class ApplyGameSettingsUseCase : IApplyGameSettingsUseCase
    {
        public void Execute()
        {
            IPersistenceService persistenceService = ServiceLocator.Get<IPersistenceService>();
            IAudioService audioService = ServiceLocator.Get<IAudioService>();

            GameSettingsPersistence gameSettings = persistenceService.GameSettingsSerializable.Data;

            if (gameSettings.Fullscreen)
            {
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            else
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }

            audioService.SetMusicMuted(!gameSettings.AudioMusicEnabled);
            audioService.SetFxMuted(!gameSettings.AudioFxEnabled);

            QualitySettings.vSyncCount = 1;
        }
    }
}
