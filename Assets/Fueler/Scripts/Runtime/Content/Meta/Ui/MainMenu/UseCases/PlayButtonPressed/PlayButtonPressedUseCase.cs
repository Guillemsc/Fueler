using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.GetLastPlayedLevel;
using Fueler.Content.Shared.Levels.UseCases.IsFirstTimeExperience;
using Fueler.Content.Shared.Levels.UseCases.IsLevelCompleted;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelByIndex;
using Fueler.Content.Shared.Levels.UseCases.TryGetLevelIndexByLevelId;
using Fueler.Contexts.Shared.UseCases.UnloadMetaAndLoadStage;
using System;
using System.Threading;

namespace Fueler.Content.Meta.Ui.MainMenu.UseCases.PlayButtonPressed
{
    public class PlayButtonPressedUseCase : IPlayButtonPressedUseCase
    {
        private readonly ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase;
        private readonly IIsFirstTimeExperienceUseCase isFirstTimeExperienceUseCase;
        private readonly IGetLastPlayedLevelUseCase getLastPlayedLevelUseCase;
        private readonly ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase;
        private readonly IUnloadMetaAndLoadStageUseCase unloadMetaAndLoadStageUseCase;

        public PlayButtonPressedUseCase(
            ITryGetLevelByIndexUseCase tryGetLevelByIndexUseCase,
            IIsFirstTimeExperienceUseCase isFirstTimeExperienceUseCase,
            IGetLastPlayedLevelUseCase getLastPlayedLevelUseCase,
            ITryGetLevelIndexByLevelIdUseCase tryGetLevelIndexByLevelIdUseCase,
            IUnloadMetaAndLoadStageUseCase unloadMetaAndLoadStageUseCase
            )
        {
            this.tryGetLevelByIndexUseCase = tryGetLevelByIndexUseCase;
            this.isFirstTimeExperienceUseCase = isFirstTimeExperienceUseCase;
            this.getLastPlayedLevelUseCase = getLastPlayedLevelUseCase;
            this.tryGetLevelIndexByLevelIdUseCase = tryGetLevelIndexByLevelIdUseCase;
            this.unloadMetaAndLoadStageUseCase = unloadMetaAndLoadStageUseCase;
        }

        public void Execute()
        {
            bool firstTime = isFirstTimeExperienceUseCase.Execute();

            if (firstTime)
            {
                LoadFistTime();
                return;
            }

            LoadContinue();
        }

        private void LoadFistTime()
        {
            bool found = tryGetLevelByIndexUseCase.Execute(levelIndex: 0, out ILevelConfiguration levelConfiguration);

            if (!found)
            {
                return;
            }

            unloadMetaAndLoadStageUseCase.Execute(levelConfiguration, CancellationToken.None).RunAsync();
        }

        private void LoadContinue()
        {
            Guid lastPlayedLevel = getLastPlayedLevelUseCase.Execute(out bool lastPlayedLevelCompleted);

            bool indexFound = tryGetLevelIndexByLevelIdUseCase.Execute(
                lastPlayedLevel, 
                out int levelIndex
                );

            if(!indexFound)
            {
                LoadFistTime();
                return;
            }

            if(lastPlayedLevelCompleted)
            {
                ++levelIndex;
            }

            bool levelFound = tryGetLevelByIndexUseCase.Execute(levelIndex, out ILevelConfiguration levelConfiguration);

            if(!levelFound)
            {
                LoadFistTime();
            }

            unloadMetaAndLoadStageUseCase.Execute(levelConfiguration, CancellationToken.None).RunAsync();
        }
    }
}
