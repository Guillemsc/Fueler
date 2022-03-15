using Juce.Persistence.Serialization;
using System.IO;

namespace Fueler.Content.Services.Cheats.UseCases.ClearAllUserData
{
    public class ClearAllUserDataUseCase : IClearAllUserDataUseCase
    {
        public void Execute()
        {
            string directory = SerializableDataUtils.GetPersistenceDataFolder();

            if (!Directory.Exists(directory))
            {
                return;
            }

            Directory.Delete(SerializableDataUtils.GetPersistenceDataFolder(), recursive: true);

            UnityEngine.Debug.Log("User data cleared");
        }
    }
}
