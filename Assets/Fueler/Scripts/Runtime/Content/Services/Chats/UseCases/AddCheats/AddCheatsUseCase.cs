using Fueler.Content.Services.Cheats.UseCases.ClearAllUserData;
using Juce.Cheats.Core;

namespace Fueler.Content.Services.Cheats.UseCases.AddCheats
{
    public class AddCheatsUseCase : IAddCheatsUseCase
    {
        private readonly IClearAllUserDataUseCase clearAllUserDataUseCase;

        public AddCheatsUseCase(
            IClearAllUserDataUseCase clearAllUserDataUseCase
            )
        {
            this.clearAllUserDataUseCase = clearAllUserDataUseCase;
        }

        public void Execute()
        {
            JuceCheats.AddAction("Clear All User Data", clearAllUserDataUseCase.Execute);
        }
    }
}
