namespace Fueler.Content.Stage.Level.Data
{
    public class RanOutOfTimeLevelFinishedCause : ILevelFinishedCause
    {
        public static readonly RanOutOfTimeLevelFinishedCause Instance = new RanOutOfTimeLevelFinishedCause();

        private RanOutOfTimeLevelFinishedCause()
        {

        }

        public void Accept(ILevelFinishedCauseVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
