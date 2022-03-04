using Fueler.Content.StageUi.General.Installers;
using Fueler.Content.StageUi.Shared.Installers;
using Fueler.Content.StageUi.Ui.Level;
using Fueler.Context.Shared.Installers;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.StageUi
{
    public class StageUiContextInstaller : MonoBehaviour, IContextInstaller<StageUiContextInstance>
    {
        public void Install(IDIContainerBuilder container, StageUiContextInstance instance)
        {
            container.InstallContextShared();
            container.InstallServices();
            container.InstallGeneral();

            container.Bind(instance.LevelUiInstaller);
            container.Bind(instance.LevelCompletedUiInstaller);
            container.Bind(instance.LevelFailedUiInstaller);

            container.Bind<IStageUiContextInteractor>()
                .FromFunction(c => new StageUiContextInteractor(
                    c.Resolve<ILevelUiInteractor>()
                    ));
        }
    }
}
