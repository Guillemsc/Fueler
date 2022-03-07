using Fueler.Content.Meta.Ui.Options.Persistence;
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

            GameSettingsPersistence gameSettings = persistenceService.GameSettingsSerializable.Data;

            if (gameSettings.Fullscreen)
            {
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            else
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
        }
    }
}
