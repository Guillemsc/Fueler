using System;

namespace Fueler.Content.Shared.Levels.UseCases.GetLastPlayedLevel
{
    public interface IGetLastPlayedLevelUseCase
    {
        Guid Execute(out bool completed);
    }
}
