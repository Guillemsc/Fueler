using Fueler.Content.Stage.Fuel.UseCases.ShipFuelUsed;
using Fueler.Content.Stage.Time.UseCases.TryStartTime;

namespace Fueler.Content.Stage.Ship.UseCases.ShipMoves
{
    public class ShipMovesUseCase : IShipMovesUseCase
    {
        private readonly IShipFuelUsedUseCase shipFuelUsedUseCase;
        private readonly ITryStartTimeUseCase tryStartTimeUseCase;

        public ShipMovesUseCase(
            IShipFuelUsedUseCase shipFuelUsedUseCase,
            ITryStartTimeUseCase tryStartTimeUseCase
            )
        {
            this.shipFuelUsedUseCase = shipFuelUsedUseCase;
            this.tryStartTimeUseCase = tryStartTimeUseCase;
        }

        public void Execute()
        {
            shipFuelUsedUseCase.Execute();
            tryStartTimeUseCase.Execute();
        }
    }
}
