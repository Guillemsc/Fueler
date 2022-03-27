namespace Fueler.Content.Stage.Accessibility.Persistence
{
    [System.Serializable]
    public class AccessibilityPersistence
    {
        public static readonly string Path = "Accessibility";

        public bool InfiniteFuel { get; set; } = false;
        public bool InfiniteTime { get; set; } = false;

        public override string ToString()
        {
            return string.Format(
                "({0}-{1}) ({2}-{3})",
                nameof(InfiniteFuel),
                InfiniteFuel,
                nameof(InfiniteTime),
                InfiniteTime
                );
        }
    }
}
