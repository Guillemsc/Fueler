using System;

namespace Fueler.Content.Shared.Levels.UseCases.TryGetLastUncompletedLevel
{
    public interface ITryGetLastUncompletedLevelUseCase
    {
        bool Execute(out Guid levelUid);
    }
}
