using Fueler.Content.Stage.General.Entities;
using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Fueler.Content.Stage.General.Factories
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
