using Fueler.Content.Shared.Levels.Configuration;

namespace Fueler.Content.Shared.Levels.UseCases.SetLevelAsLastPlayedLevel
{
    public interface ISetLevelAsLastPlayedLevelUseCase
    {
        void Execute(ILevelConfiguration levelConfiguration, bool serialize);
    }
}
