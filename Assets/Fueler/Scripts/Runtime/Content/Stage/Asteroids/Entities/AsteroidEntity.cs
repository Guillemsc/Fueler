using Fueler.Content.Stage.Ship.Visitors;
using UnityEngine;

namespace Fueler.Content.Stage.Asteroids.Entities
{
    public class AsteroidEntity : MonoBehaviour, IShipCollider
    {
        public void Accept(IShipColliderVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
