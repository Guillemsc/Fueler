using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.LoadingScreen.LoadingScreenUi.UseCases.SetVisible
{
    public interface ISetVisibleUseCase
    {
        Task Execute(bool set, CancellationToken cancellationToken);
    }
}
