using Fueler.Content.Stage.Tutorial.Persistence;
using Juce.Persistence.Serialization;
using System.IO;
using UnityEditor;

namespace Fueler.Content.Shared.Levels.Persistence
{
    public static class PersistenceMenuItems
    {
        [MenuItem("Fueler/ClearAllUserData")]
        public static void ClearAllUserData()
        {
            Directory.Delete(SerializableDataUtils.GetPersistenceDataFolder(), recursive: true);

            UnityEngine.Debug.Log("User data cleared");
        }

        [MenuItem("Fueler/ClearTutorialUserData")]
        public static void ClearTutorialUserData()
        {
            File.Delete(SerializableDataUtils.GetPersistenceDataFilepath(TutorialPersistence.Path));

            UnityEngine.Debug.Log("Tutorial user data cleared");
        }
    }
}
