using Juce.Core.Time;
using Juce.CoreUnity.Time;

namespace Fueler.Content.Stage.Time.Data
{
    public class TimeData
    {
        public int MaxTime { get; set; }
        public int TimeLeft { get; set; }
        public ITimer Timer { get; } = new ScaledUnityTimer();
        public bool ShowedLowTimeWarning { get; set; }
    }
}
