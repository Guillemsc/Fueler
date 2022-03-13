using Fueler.Content.Stage.Ship.Visitors;
using UnityEngine;

namespace Fueler.Content.Stage.General.Entities
{
    public class LevelEndEntity : MonoBehaviour, IShipCollider
    {
        public void Accept(IShipColliderVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
