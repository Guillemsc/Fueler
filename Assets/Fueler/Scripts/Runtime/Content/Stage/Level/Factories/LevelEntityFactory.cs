using Fueler.Content.Stage.Level.Entities;
using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Fueler.Content.Stage.Level.Factories
{
    public class LevelEntityFactory : MonoBehaviourUnknownPrefabFactory<LevelEntityFactoryDefinition, LevelEntity>
    {
        public LevelEntityFactory(Transform parent) : base(parent)
        {

        }

        protected override void Init(LevelEntityFactoryDefinition definition, LevelEntity creation)
        {
            
        }
    }
}
