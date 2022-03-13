using Fueler.Content.Stage.Astrounats.Entities;
using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.Ship.Entities;

namespace Fueler.Content.Stage.Ship.Visitors
{
    public interface IShipColliderVisitor
    {
        void Visit(LevelEndEntity entity);
        void Visit(AstronautEntity entity);
        void Visit(ShipKillerEntity entity);
    }
}
