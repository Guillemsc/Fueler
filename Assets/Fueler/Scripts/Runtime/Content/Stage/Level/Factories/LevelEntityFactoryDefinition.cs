using Fueler.Content.Stage.Level.Entities;
using Juce.CoreUnity.Factories;

namespace Fueler.Content.Stage.Level.Factories
{
    public class LevelEntityFactoryDefinition : MonoBehaviourUnknownPrefabFactoryDefinition<LevelEntity>
    {
        public LevelEntity Prefab { get; }

        public LevelEntityFactoryDefinition(
            LevelEntity prefab
            )
        {
            Prefab = prefab;
        }
    }
}
