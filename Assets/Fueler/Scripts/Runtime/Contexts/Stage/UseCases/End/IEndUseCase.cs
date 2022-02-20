using Fueler.Content.Stage.Data;

namespace Fueler.Contexts.Stage.UseCases.End
{
    public interface IEndUseCase
    {
        void Execute(LevelEndData levelEndData);
    }
}
