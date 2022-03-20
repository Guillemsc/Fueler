using Juce.Core.DI.Builder;
using Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowAstronautsTutorialPanel;
using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Services.Persistence;
using Juce.CoreUnity.ViewStack;
using Fueler.Content.StageUi.Ui.ObjectivesPopup;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowTutorialPanels;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowControlsTutorial;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowFuelTutorialPanel;
using Fueler.Content.Stage.Fuel.Data;
using Fueler.Content.Stage.Tutorial.UseCases.TryShowTimeTutorialPanel;
using Fueler.Content.Stage.Time.Data;

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

            container.Bind<ITryShowControlsTutorialPanelUseCase>()
                .FromFunction(c => new TryShowControlsTutorialPanelUseCase(
                    c.Resolve<IPersistenceService>().TutorialSerializable,
                    c.Resolve<IShowObjectivesPopupTutorialPanelUseCase>()
                    ));

            container.Bind<ITryShowFuelTutorialPanelUseCase>()
                .FromFunction(c => new TryShowFuelTutorialPanelUseCase(
                    c.Resolve<FuelData>(),
                    c.Resolve<IPersistenceService>().TutorialSerializable,
                    c.Resolve<IShowObjectivesPopupTutorialPanelUseCase>()
                    ));

            container.Bind<ITryShowAstronautsTutorialPanelUseCase>()
                .FromFunction(c => new TryShowAstronautsTutorialPanelUseCase(
                    c.Resolve<AstronautsData>(),
                    c.Resolve<IPersistenceService>().TutorialSerializable,
                    c.Resolve<IShowObjectivesPopupTutorialPanelUseCase>()
                    ));

            container.Bind<ITryShowTimeTutorialPanelUseCase>()
                .FromFunction(c => new TryShowTimeTutorialPanelUseCase(
                    c.Resolve<TimeData>(),
                    c.Resolve<IPersistenceService>().TutorialSerializable,
                    c.Resolve<IShowObjectivesPopupTutorialPanelUseCase>()
                    ));

            container.Bind<ITryShowTutorialPanelsUseCase>()
                .FromFunction(c => new TryShowTutorialPanelsUseCase(
                    c.Resolve<ITryShowControlsTutorialPanelUseCase>(),
                    c.Resolve<ITryShowFuelTutorialPanelUseCase>(),
                    c.Resolve<ITryShowAstronautsTutorialPanelUseCase>(),
                    c.Resolve<ITryShowTimeTutorialPanelUseCase>()
                    ));
        }
    }
}
