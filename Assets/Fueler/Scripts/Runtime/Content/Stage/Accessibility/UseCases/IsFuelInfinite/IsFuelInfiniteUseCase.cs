using Fueler.Content.Stage.Accessibility.Data;

namespace Fueler.Content.Stage.Accessibility.UseCases.IsFuelInfinite
{
    public class IsFuelInfiniteUseCase : IIsFuelInfiniteUseCase
    {
        private readonly AccessibilityData accessibilityData;

        public IsFuelInfiniteUseCase(
            AccessibilityData accessibilityData
            )
        {
            this.accessibilityData = accessibilityData;
        }

        public bool Execute()
        {
            return accessibilityData.InfiniteFuel;
        }
    }
}
