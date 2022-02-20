using Fueler.Content.Stage.Data;

namespace Fueler.Content.Stage.Level.UseCases.EndLevel
{
    public interface IEndLevelUseCase
    {
        void Execute(LevelEndData levelEndedData);
    }
}
