using Fueler.Content.Meta.Ui.MainMenu;
using Fueler.Content.Services.MetaAudio;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Shared.UseCases.UnloadStage;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta
{
    public class UnloadStageAndLoadMetaUseCase : IUnloadStageAndLoadMetaUseCase
    {
        private readonly IUnloadStageUseCase unloadStageUseCase;

        public UnloadStageAndLoadMetaUseCase(
            IUnloadStageUseCase unloadStageUseCase
            )
        {
            this.unloadStageUseCase = unloadStageUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            IContextFactories contextFactories = ServiceLocator.Get<IContextFactories>();

            await unloadStageUseCase.Execute(cancellationToken);
            await contextFactories.Meta.Create();

            IUiViewStack viewStack = ServiceLocator.Get<IUiViewStack>();

            await viewStack.New()
                .Callback(StartMetaAudio)
                .Show<IMainMenuUiInteractor>(instantly: true)
                .Execute(cancellationToken);

            await loadingToken.Complete();
        }

        private void StartMetaAudio()
        {
            IMetaAudioService metaAudioService = ServiceLocator.Get<IMetaAudioService>();

            metaAudioService.Play(CancellationToken.None).RunAsync();
        }
    }
}
