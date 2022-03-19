namespace Fueler.Content.Stage.Level.Data
{
    public class LevelEndData
    {
        public bool Completed { get; private set; }
        public bool DestroyShip { get; private set; }

        private LevelEndData()
        {
      
        }

        public static LevelEndData FromDestination()
        {
            return new LevelEndData()
            {
                Completed = true,
                DestroyShip = false
            };
        }

        public static LevelEndData FromShipDestroyed()
        {
            return new LevelEndData()
            {
                Completed = false,
                DestroyShip = true
            };
        }

        public static LevelEndData FromRanOutOfTime()
        {
            return new LevelEndData()
            {
                Completed = false,
                DestroyShip = false,
            };
        }
    }
}
