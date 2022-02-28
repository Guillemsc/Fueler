using Fueler.Content.Stage.General.Entities;

namespace Fueler.Content.Stage.General.UseCases.LoadLevel
{
    public interface ILoadLevelUseCase
    {
        bool Execute(LevelEntity levelEntityPrefab, out LevelEntity levelEntity);
    }
}
