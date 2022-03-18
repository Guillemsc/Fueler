using System;

namespace Fueler.Content.Shared.Levels.UseCases.IsLastLevel
{
    public interface IIsLastLevelUseCase
    {
        bool Execute(Guid levelUid);
    }
}
