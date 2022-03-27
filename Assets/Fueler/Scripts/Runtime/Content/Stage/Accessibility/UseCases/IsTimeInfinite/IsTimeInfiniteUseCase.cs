using Fueler.Content.Stage.Accessibility.Data;

namespace Fueler.Content.Stage.Accessibility.UseCases.IsTimeInfinite
{
    public class IsTimeInfiniteUseCase : IIsTimeInfiniteUseCase
    {
        private readonly AccessibilityData accessibilityData;

        public IsTimeInfiniteUseCase(
            AccessibilityData accessibilityData
            )
        {
            this.accessibilityData = accessibilityData;
        }

        public bool Execute()
        {
            return accessibilityData.InfiniteTime;
        }
    }
}
