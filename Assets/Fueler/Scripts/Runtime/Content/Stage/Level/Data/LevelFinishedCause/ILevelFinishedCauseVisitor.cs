namespace Fueler.Content.Stage.Level.Data
{
    public interface ILevelFinishedCauseVisitor
    {
        void Visit(ReachedEndDestinationLevelFinishedCause cause);
        void Visit(RanOutOfTimeLevelFinishedCause cause);
        void Visit(ShipDestroyedLevelFinishedCause cause);
    }
}
