using Fueler.Content.Meta.Ui.MainMenu;
using Fueler.Content.StageUi.Shared.Installers;
using Fueler.Context.Shared.Installers;
using Juce.Core.DI.Builder;
using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Fueler.Contexts.Meta
{
    public class MetaContextInstaller : MonoBehaviour, IContextInstaller<MetaContextInstance>
    {
        public void Install(IDIContainerBuilder container, MetaContextInstance instance)
        {
            container.InstallContextShared();
            container.InstallServices();

            container.Bind(instance.SplashScreenUiInstaller);
            container.Bind(instance.MainMenuUiInstaller);
            container.Bind(instance.OptionsUiInstaller);

            container.Bind<IMetaContextInteractor>()
                .FromFunction(c => new MetaContextInteractor(
                    c.Resolve<IMainMenuUiInteractor>()
                    ));
        }
    }
}
