namespace Fueler.Content.Stage.Ship.Visitors
{
    public interface IShipCollider
    {
        void Accept(IShipColliderVisitor visitor);
    }
}
