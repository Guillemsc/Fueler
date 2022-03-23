namespace Fueler.Content.Stage.Level.Data
{
    public class ShipDestroyedLevelFinishedCause : ILevelFinishedCause
    {
        public static readonly ShipDestroyedLevelFinishedCause Instance = new ShipDestroyedLevelFinishedCause();

        private ShipDestroyedLevelFinishedCause()
        {

        }

        public void Accept(ILevelFinishedCauseVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
