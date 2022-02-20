using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.LoadingScreen.LoadingScreenUi
{
    public interface ILoadingScreenUiInteractor
    {
        Task SetVisible(bool visibe, CancellationToken cancellationToken);
    }
}
