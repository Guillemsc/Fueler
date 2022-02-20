using Juce.Core.Loading;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Context.LoadingScreen.UseCases.Show
{
    public interface IShowUseCase 
    {
        Task<ILoadingToken> Execute(CancellationToken cancellationToken);
    }
}
