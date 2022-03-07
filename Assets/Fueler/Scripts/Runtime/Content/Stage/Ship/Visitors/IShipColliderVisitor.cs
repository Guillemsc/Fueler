using Fueler.Content.Stage.Astrounats.Entities;
using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.Ship.Visitors
{
    public interface IShipColliderVisitor
    {
        void Visit(AstronautEntity entity);
        void Visit(ShipKillerEntity entity);
    }
}
