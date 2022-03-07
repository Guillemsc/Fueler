using Juce.Core.DI.Builder;
using Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowAstronautsTutorialPanel;
using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Services.Persistence;
using Juce.CoreUnity.ViewStack;
using Fueler.Content.StageUi.Ui.ObjectivesPopup;

namespace Fueler.Content.Stage.Tutorial.Installers
{
    public static class TutorialInstaller
    {
        public static void InstallTutorial(this IDIContainerBuilder container)
        {
            container.Bind<IShowObjectivesPopupTutorialPanelUseCase>()
                .FromFunction(c => new ShowObjectivesPopupTutorialPanelUseCase(
                    c.Resolve<IUiViewStack>(),
                    c.Resolve<IObjectivesPopupUiInteractor>()
                    ));

            container.Bind<ITryShowAstronautsTutorialPanelUseCase>()
                .FromFunction(c => new TryShowAstronautsTutorialPanelUseCase(
                    c.Resolve<AstronautsData>(),
                    c.Resolve<IPersistenceService>().TutorialSerializable,
                    c.Resolve<IShowObjectivesPopupTutorialPanelUseCase>()
                    ));
        }
    }
}
