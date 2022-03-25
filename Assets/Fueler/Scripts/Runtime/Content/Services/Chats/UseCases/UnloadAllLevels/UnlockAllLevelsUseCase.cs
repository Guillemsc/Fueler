using Fueler.Content.Services.Configuration;
using Fueler.Content.Services.Persistence;
using Fueler.Content.Shared.Levels.Configuration;
using System.Threading;

namespace Fueler.Content.Services.Cheats.UseCases.UnlockAllLevels
{
    public class UnlockAllLevelsUseCase : IUnlockAllLevelsUseCase
    {
        private readonly IConfigurationService configurationService;
        private readonly IPersistenceService persistenceService;

        public UnlockAllLevelsUseCase(
            IConfigurationService configurationService,
            IPersistenceService persistenceService
            )
        {
            this.configurationService = configurationService;
            this.persistenceService = persistenceService;
        }

        public void Execute()
        {
            persistenceService.LevelsSerializable.Data.CompletedLevels.Clear();

            foreach(ILevelConfiguration levelConfiguration in configurationService.LevelsConfiguration.Levels)
            {
                persistenceService.LevelsSerializable.Data.CompletedLevels.Add(levelConfiguration.Id);
            }

            persistenceService.LevelsSerializable.Save(CancellationToken.None).RunAsync();
        }
    }
}
