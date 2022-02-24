using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex
{
    public interface ITryGetLevelByIndexUseCase
    {
        bool Execute(int levelIndex, out ILevelConfiguration levelConfiguration);
    }
}
