using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.Camera
{
    public class CameraContextInstaller : MonoBehaviour, IContextInstaller<CameraContextInstance>
    {
        public void Install(IDIContainerBuilder container, CameraContextInstance instance)
        {
            container.Bind<ICameraContextInteractor>()
                .FromFunction(c => new CameraContextInteractor());
        }
    }
}
