using Fueler.Content.Meta.Ui.MainMenu;
using Fueler.Content.Meta.Ui.SplashScreen;
using Fueler.Content.Services.MetaAudio;
using Fueler.Content.Services.Persistence;
using Fueler.Contexts.LoadingScreen;
using Fueler.Contexts.Shared.UseCases.ApplyGameSettings;
using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.LoadMainEntryPoint
{
    public class LoadMainEntryPointUseCase : ILoadMainEntryPointUseCase
    {
        private readonly IApplyGameSettingsUseCase applyGameSettingsUseCase;

        public LoadMainEntryPointUseCase(
            IApplyGameSettingsUseCase applyGameSettingsUseCase
            )
        {
            this.applyGameSettingsUseCase = applyGameSettingsUseCase;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken loadingToken = await loadingScreen.Value.Show(cancellationToken);

            IPersistenceService persistenceService = ServiceLocator.Get<IPersistenceService>();

            await persistenceService.LoadAll(cancellationToken);
            applyGameSettingsUseCase.Execute();

            IContextFactories contextFactories = ServiceLocator.Get<IContextFactories>();

            await contextFactories.Meta.Create();

            await loadingToken.Complete();

            IUiViewStack viewStack = ServiceLocator.Get<IUiViewStack>();

            await viewStack.New()
                .Show<ISplashScreenUiInteractor>(instantly: false)
                .Hide<ISplashScreenUiInteractor>(instantly: false)
                .Callback(StartMetaAudio)
                .Show<IMainMenuUiInteractor>(instantly: false)
                .Execute(cancellationToken);
        }

        private void StartMetaAudio()
        {
            IMetaAudioService metaAudioService = ServiceLocator.Get<IMetaAudioService>();

            metaAudioService.Play(CancellationToken.None).RunAsync();
        }
    }
}
