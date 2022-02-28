using Fueler.Content.Stage.General.Entities;
using Juce.CoreUnity.Factories;

namespace Fueler.Content.Stage.General.Factories
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
