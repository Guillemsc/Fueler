using Fueler.Content.Stage.Ship.Visitors;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipKillerEntity : MonoBehaviour, IShipCollider
    {
        public void Accept(IShipColliderVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
