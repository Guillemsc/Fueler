using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.Camera
{
    public class CameraContextInstaller : IContextInstaller<CameraContextInstance>
    {
        public void Install(IDIContainerBuilder container, CameraContextInstance instance)
        {
            container.Bind<ICameraContextInteractor>()
                .FromFunction(c => new CameraContextInteractor());
        }
    }
}
