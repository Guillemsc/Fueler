using Fueler.Content.LoadingScreen.LoadingScreenUi;
using UnityEngine;

namespace Fueler.Contexts.LoadingScreen
{
    public class LoadingScreenContextInstance : MonoBehaviour
    {
        [SerializeField] private LoadingScreenUiInstaller loadingScreenUiInstaller = default;

        public LoadingScreenUiInstaller LoadingScreenUiInstaller => loadingScreenUiInstaller;
    }
}
