using Fueler.Content.Stage.Ship.Entities;
using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Factories
{
    public class ShipEntityFactory : MonoBehaviourKnownPrefabFactory<ShipEntityFactoryDefinition, ShipEntity>
    {
        public ShipEntityFactory(ShipEntity prefab, Transform parent) : base(prefab, parent)
        {

        }

        protected override void Init(ShipEntityFactoryDefinition definition, ShipEntity creation)
        {

        }
    }
}
