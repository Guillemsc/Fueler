using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.CoreUnity.Contexts;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstaller : IContextInstaller<IStageUiContextInteractor, StageUiContextInstance>
    {
        public IDisposable<IStageUiContextInteractor> Install(StageUiContextInstance instance, params IDIContainer[] parentContainers)
        {
            IDIContainerBuilder uiContainerBuilder = new DIContainerBuilder();
            {
                uiContainerBuilder.Bind(parentContainers);

                uiContainerBuilder.Bind<StageUiContextInstance>().FromInstance(instance);
            }
            IDIContainer uiContainer = uiContainerBuilder.Build();

            IDIContainerBuilder containerBuilder = new DIContainerBuilder();
            {
 
            }
            IDIContainer container = uiContainerBuilder.Build();

            IStageUiContextInteractor interactor = new StageUiContextInteractor(
                );

            return new Disposable<IStageUiContextInteractor>(interactor, (IStageUiContextInteractor _) => { });
        }
    }
}
