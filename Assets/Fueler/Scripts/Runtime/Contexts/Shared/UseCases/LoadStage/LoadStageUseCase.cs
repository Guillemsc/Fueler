using Fueler.Content.Services.StageAudio;
using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Contexts.Stage;
using Fueler.Contexts.StageUi;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Disposables;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Contexts.Shared.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        public async Task<IStageContextInteractor> Execute(
            ILevelConfiguration levelConfiguration,
            CancellationToken cancellationToken
            )
        {
            IContextFactories contextFactories = ServiceLocator.Get<IContextFactories>();

            IDIContainer configurationContainer = DIContainerBuilderUtils.Build(levelConfiguration);

            ITaskDisposable<IStageUiContextInteractor> stageUiInteractor = await contextFactories.StageUi.Create(
                configurationContainer
                );
            ITaskDisposable<IStageContextInteractor> stageInteractor = await contextFactories.Stage.Create(
                configurationContainer,
                stageUiInteractor.Value.ToContainer()
                );

            await stageInteractor.Value.Load(cancellationToken);

            IStageAudioService stageAudioService = ServiceLocator.Get<IStageAudioService>();
            stageAudioService.Play(cancellationToken).RunAsync();

            return stageInteractor.Value;
        }
    }
}
