using System;

namespace Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId
{
    public interface ITryGetLevelIndexByLevelIdUseCase
    {
        bool Execute(Guid levelId, out int index);
    }
}
