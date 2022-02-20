using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.CoreUnity.Contexts;

namespace Fueler.Contexts.Camera
{
    public class CameraContextInstaller : IContextInstaller<ICameraContextInteractor, CameraContextInstance>
    {
        public IDisposable<ICameraContextInteractor> Install(CameraContextInstance instance, params IDIContainer[] parentContainers)
        {
            return new Disposable<ICameraContextInteractor>(new CameraContextInteractor(), (ICameraContextInteractor _) => { });
        }
    }
}
