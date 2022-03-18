using System;

namespace Fueler.Content.Shared.Levels.UseCases.IsLevelCompleted
{
    public interface IIsLevelCompletedUseCase 
    {
        bool Execute(Guid levelUid);
    }
}
