using Fueler.Content.StageUi.Ui.Level;
using Fueler.Content.StageUi.Ui.ObjectivesPopup;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInteractor : IStageUiContextInteractor
    {
        private readonly ILevelUiInteractor levelUiInteractor;
        private readonly IObjectivesPopupUiInteractor objectivesPopupUiInteractor;

        public StageUiContextInteractor(
            ILevelUiInteractor levelUiInteractor,
            IObjectivesPopupUiInteractor objectivesPopupUiInteractor
            )
        {
            this.levelUiInteractor = levelUiInteractor;
            this.objectivesPopupUiInteractor = objectivesPopupUiInteractor;
        }

        public IDIContainer ToContainer()
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind<ILevelUiInteractor>().FromInstance(levelUiInteractor);
            containerBuilder.Bind<IObjectivesPopupUiInteractor>().FromInstance(objectivesPopupUiInteractor);

            return containerBuilder.Build();
        }
    }
}
