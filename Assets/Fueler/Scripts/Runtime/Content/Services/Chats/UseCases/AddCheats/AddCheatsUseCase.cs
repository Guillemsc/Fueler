using Fueler.Content.Services.Cheats.UseCases.ClearAllUserData;
using Fueler.Content.Services.Cheats.UseCases.UnlockAllLevels;
using Juce.Cheats.Core;

namespace Fueler.Content.Services.Cheats.UseCases.AddCheats
{
    public class AddCheatsUseCase : IAddCheatsUseCase
    {
        private readonly IClearAllUserDataUseCase clearAllUserDataUseCase;
        private readonly IUnlockAllLevelsUseCase unlockAllLevelsUseCase;

        public AddCheatsUseCase(
            IClearAllUserDataUseCase clearAllUserDataUseCase,
            IUnlockAllLevelsUseCase unlockAllLevelsUseCase
            )
        {
            this.clearAllUserDataUseCase = clearAllUserDataUseCase;
            this.unlockAllLevelsUseCase = unlockAllLevelsUseCase;
        }

        public void Execute()
        {
            JuceCheats.AddAction("Clear All User Data", clearAllUserDataUseCase.Execute);
            JuceCheats.AddAction("Unlock All Levels", unlockAllLevelsUseCase.Execute);
        }
    }
}
