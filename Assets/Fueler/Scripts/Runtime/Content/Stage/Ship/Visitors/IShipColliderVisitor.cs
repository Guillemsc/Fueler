using Fueler.Content.Stage.Asteroids.Entities;
using Fueler.Content.Stage.Astrounats.Entities;

namespace Fueler.Content.Stage.Ship.Visitors
{
    public interface IShipColliderVisitor
    {
        void Visit(AsteroidEntity entity);
        void Visit(AstronautEntity entity);
    }
}
