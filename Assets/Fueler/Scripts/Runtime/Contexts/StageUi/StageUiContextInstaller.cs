using Fueler.Content.StageUi.General.Installers;
using Fueler.Content.StageUi.Ui.Level;
using Fueler.Content.StageUi.Ui.ObjectivesPopup;
using Fueler.Context.Shared.Installers;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstaller : IContextInstaller<StageUiContextInstance>
    {
        public void Install(IDIContainerBuilder container, StageUiContextInstance instance)
        {
            container.InstallContextShared();
            container.InstallServices();
            container.InstallGeneral();

            container.Bind(instance.LevelUiInstaller);
            container.Bind(instance.LevelCompletedUiInstaller);
            container.Bind(instance.LevelFailedUiInstaller);
            container.Bind(instance.AllLevelsCompletedUiInstaller);
            container.Bind(instance.ObjectivesPopupUiInstaller);

            container.Bind<IStageUiContextInteractor>()
                .FromFunction(c => new StageUiContextInteractor(
                    c.Resolve<ILevelUiInteractor>(),
                    c.Resolve<IObjectivesPopupUiInteractor>()
                    ));
        }
    }
}
