using Fueler.Content.Stage.General.Entities;

namespace Fueler.Content.Stage.Level.Data
{
    public class ReachedEndDestinationLevelFinishedCause : ILevelFinishedCause
    {
        public LevelEndEntity LevelEndEntity { get; }

        public ReachedEndDestinationLevelFinishedCause(
            LevelEndEntity levelEndEntity
            )
        {
            LevelEndEntity = levelEndEntity;
        }

        public void Accept(ILevelFinishedCauseVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
