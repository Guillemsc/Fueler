using Fueler.Content.StageUi.Ui.Level;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInteractor : IStageUiContextInteractor
    {
        private readonly ILevelUiInteractor levelUiInteractor;

        public StageUiContextInteractor(
            ILevelUiInteractor levelUiInteractor
            )
        {
            this.levelUiInteractor = levelUiInteractor;
        }

        public IDIContainer ToContainer()
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind<ILevelUiInteractor>().FromInstance(levelUiInteractor);

            return containerBuilder.Build();
        }
    }
}
