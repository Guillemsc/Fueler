using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.TrySpawnLevelEntry
{
    public interface ITrySpawnLevelEntryUseCase
    {
        bool Execute(
            int index, 
            bool locked,
            ILevelConfiguration levelConfiguration, 
            out LevelTextButtonWidget levelEntry
            );
    }
}
