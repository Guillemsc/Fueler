using Fueler.Content.Services.Persistence;
using Fueler.Content.Stage.Accessibility.Data;
using Fueler.Content.Stage.Accessibility.UseCases.IsFuelInfinite;
using Fueler.Content.Stage.Accessibility.UseCases.IsTimeInfinite;
using Juce.Core.DI.Builder;

namespace Fueler.Content.Stage.Accessibility.Installers
{
    public static class AccessibilityInstaller
    {
        public static void InstallAccessibility(this IDIContainerBuilder container)
        {
            container.Bind<AccessibilityData>()
                .FromFunction(c => new AccessibilityData(
                    c.Resolve<IPersistenceService>().AccessibilitySerializable.Data.InfiniteFuel,
                    c.Resolve<IPersistenceService>().AccessibilitySerializable.Data.InfiniteTime
                    ));

            container.Bind<IIsFuelInfiniteUseCase>()
                .FromFunction(c => new IsFuelInfiniteUseCase(
                    c.Resolve<AccessibilityData>()
                    ));

            container.Bind<IIsTimeInfiniteUseCase>()
                .FromFunction(c => new IsTimeInfiniteUseCase(
                    c.Resolve<AccessibilityData>()
                    ));
        }
    }
}
