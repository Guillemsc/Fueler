using Fueler.Content.Services.Persistence;
using Fueler.Content.Stage.Accessibility.Data;
using Fueler.Content.Stage.Accessibility.UseCases.IsFuelInfinite;
using Juce.Core.DI.Builder;

namespace Fueler.Content.Stage.Accessibility.Installers
{
    public static class AccessibilityInstaller
    {
        public static void InstallAccessibility(this IDIContainerBuilder container)
        {
            container.Bind<AccessibilityData>()
                .FromFunction(c => new AccessibilityData(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable.Data.InfiniteFuel
                    ));

            container.Bind<IIsFuelInfiniteUseCase>()
                .FromFunction(c => new IsFuelInfiniteUseCase(
                    c.Resolve<AccessibilityData>()
                    ));
        }
    }
}
