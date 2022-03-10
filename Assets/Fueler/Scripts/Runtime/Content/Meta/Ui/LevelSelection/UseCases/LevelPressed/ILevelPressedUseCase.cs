using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.LevelPressed
{
    public interface ILevelPressedUseCase
    {
        void Execute(ILevelConfiguration levelConfiguration);
    }
}
