using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage;
using Juce.CoreUnity.ViewStack;
using System.Threading;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.PlayButtonPressed
{
    public class PlayButtonPressedUseCase : IPlayButtonPressedUseCase
    {
        private readonly ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase;
        private readonly IUnloadMetaAndLoadStageUseCase unloadMetaAndLoadStageUseCase;

        public PlayButtonPressedUseCase(
            ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase,
            IUnloadMetaAndLoadStageUseCase unloadMetaAndLoadStageUseCase
            )
        {
            this.tryGetLevelByIndexUseCase = tryGetLevelByIndexUseCase;
            this.unloadMetaAndLoadStageUseCase = unloadMetaAndLoadStageUseCase;
        }

        public void Execute()
        {
            bool found = tryGetLevelByIndexUseCase.Execute(levelIndex: 0, out ILevelConfiguration levelConfiguration);

            if(!found)
            {
                return;
            }

            unloadMetaAndLoadStageUseCase.Execute(levelConfiguration, CancellationToken.None).RunAsync();
        }
    }
}
