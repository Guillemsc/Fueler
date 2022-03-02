using Fueler.Content.Meta.Ui.MainMenu;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;

namespace Fueler.Contexts.Meta
{
    public class MetaContextInteractor : IMetaContextInteractor
    {
        private readonly IMainMenuUiInteractor mainMenuUiInteractor;

        public MetaContextInteractor(
            IMainMenuUiInteractor mainMenuUiInteractor
            )
        {
            this.mainMenuUiInteractor = mainMenuUiInteractor;
        }

        public IDIContainer ToContainer()
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind<IMainMenuUiInteractor>().FromInstance(mainMenuUiInteractor);

            return containerBuilder.Build();
        }
    }
}
