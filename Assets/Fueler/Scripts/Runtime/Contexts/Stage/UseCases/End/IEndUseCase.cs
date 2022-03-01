using Fueler.Content.Stage.Level.Data;

namespace Fueler.Contexts.Stage.UseCases.End
{
    public interface IEndUseCase
    {
        void Execute(LevelEndData levelEndData);
    }
}
