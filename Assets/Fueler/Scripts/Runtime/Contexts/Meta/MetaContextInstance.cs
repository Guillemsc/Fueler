using Fueler.Content.Meta.Ui.MainMenu;
using Fueler.Content.Meta.Ui.Options;
using Fueler.Content.Meta.Ui.SplashScreen;
using UnityEngine;

namespace Fueler.Contexts.Meta
{
    public class MetaContextInstance : MonoBehaviour
    {
        [SerializeField] private SplashScreenUiInstaller splashScreenUiInstaller = default;
        [SerializeField] private MainMenuUiInstaller mainMenuUiInstaller = default;
        [SerializeField] private OptionsUiInstaller optionsUiInstaller = default;

        public SplashScreenUiInstaller SplashScreenUiInstaller => splashScreenUiInstaller;
        public MainMenuUiInstaller MainMenuUiInstaller => mainMenuUiInstaller;
        public OptionsUiInstaller OptionsUiInstaller => optionsUiInstaller;
    }
}
