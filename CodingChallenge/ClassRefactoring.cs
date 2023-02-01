namespace CodingChallenge
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        private static List<SwallowVelocity> _swallowVelocities;

        public SwallowType Type { get; }

        public SwallowLoad Load { get; }

        private SwallowFactory(SwallowType swallowType, SwallowLoad load = SwallowLoad.None)
        {
            _swallowVelocities = GetDataStore();
            Type = swallowType;
            Load = load;
        }

        public static double GetAirspeedVelocity(SwallowType swallowType, SwallowLoad load)
        {
            var swallowFac = new SwallowFactory(swallowType, load);
            var swallowVel = _swallowVelocities.SingleOrDefault(sv => sv.SwallowType == swallowType && sv.Load == load);

            if (swallowVel == null)
                throw new InvalidOperationException();

            return swallowVel.Velocity;
        }

        private static List<SwallowVelocity> GetDataStore() => new()
        {
            new SwallowVelocity { Load = SwallowLoad.None, SwallowType = SwallowType.African, Velocity = 22 },
            new SwallowVelocity { Load = SwallowLoad.None, SwallowType = SwallowType.European, Velocity = 20 },
            new SwallowVelocity { Load = SwallowLoad.Coconut, SwallowType = SwallowType.African, Velocity = 18 },
            new SwallowVelocity { Load = SwallowLoad.Coconut, SwallowType = SwallowType.European, Velocity = 16 }
        };

        private class SwallowVelocity
        {
            public SwallowType SwallowType { get; init;}

            public SwallowLoad Load { get; init;}

            public int Velocity { get; init;}
        }
    }
}
