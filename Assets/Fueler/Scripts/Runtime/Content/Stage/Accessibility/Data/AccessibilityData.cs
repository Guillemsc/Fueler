namespace Fueler.Content.Stage.Accessibility.Data
{
    public class AccessibilityData
    {
        public bool InfiniteFuel { get; }
        public bool InfiniteTime { get; }

        public AccessibilityData(bool infiniteFuel, bool infiniteTime)
        {
            InfiniteFuel = infiniteFuel;
            InfiniteTime = infiniteTime;
        }
    }
}
