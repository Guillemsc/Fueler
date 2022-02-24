using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstaller : MonoBehaviour, IContextInstaller<StageUiContextInstance>
    {
        public void Install(IDIContainerBuilder container, StageUiContextInstance instance)
        {
            container.Bind(instance.EndStageUiInstaller);

            container.Bind<IStageUiContextInteractor>()
                .FromFunction(c => new StageUiContextInteractor());
        }
    }
}
