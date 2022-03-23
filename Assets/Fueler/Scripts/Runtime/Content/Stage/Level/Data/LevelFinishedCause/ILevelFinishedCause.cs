namespace Fueler.Content.Stage.Level.Data
{
    public interface ILevelFinishedCause
    {
        void Accept(ILevelFinishedCauseVisitor visitor);
    }
}
