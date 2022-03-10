using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntry
{
    public interface ISpawnLevelEntryUseCase
    {
        void Execute(int index, ILevelConfiguration levelConfiguration);
    }
}
