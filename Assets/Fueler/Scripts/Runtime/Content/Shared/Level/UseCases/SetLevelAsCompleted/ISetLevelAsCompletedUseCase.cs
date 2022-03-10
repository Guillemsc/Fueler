using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Shared.Levels.UseCases.SetLevelAsCompleted
{
    public interface ISetLevelAsCompletedUseCase
    {
        void Execute(ILevelConfiguration levelConfiguration);
    }
}
