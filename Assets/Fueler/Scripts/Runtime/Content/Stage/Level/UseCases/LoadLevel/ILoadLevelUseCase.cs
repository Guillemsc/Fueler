using Fueler.Content.Stage.Level.Entities;

namespace Fueler.Content.Stage.Level.UseCases.LoadLevel
{
    public interface ILoadLevelUseCase
    {
        bool Execute(LevelEntity levelEntityPrefab, out LevelEntity levelEntity);
    }
}
