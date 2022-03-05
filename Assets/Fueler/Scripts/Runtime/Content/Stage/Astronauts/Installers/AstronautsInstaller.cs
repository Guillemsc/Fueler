using Fueler.Content.Stage.Astrounats.Data;
using Fueler.Content.Stage.Astrounats.UseCases.AstronautCollected;
using Fueler.Content.Stage.Astrounats.UseCases.InitAstronauts;
using Fueler.Content.StageUi.Ui.Level;
using Juce.Core.DI.Builder;

namespace Fueler.Content.Stage.Astrounats.Installers
{
    public static class AstronautsInstaller
    {
        public static void InstallAstronauts(this IDIContainerBuilder container)
        {
            container.Bind<AstronautsData>().FromNew();

            container.Bind<IInitAstronautsUseCase>()
                .FromFunction(c => new InitAstronautsUseCase(
                    c.Resolve<AstronautsData>(),
                    c.Resolve<ILevelUiInteractor>()
                    ));

            container.Bind<IAstronautCollectedUseCase>()
                .FromFunction(c => new AstronautCollectedUseCase(
                    c.Resolve<AstronautsData>(),
                    c.Resolve<ILevelUiInteractor>()
                    ));
        }
    }
}
