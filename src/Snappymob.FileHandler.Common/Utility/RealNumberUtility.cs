namespace Snappymob.FileHandler.Common.Utility
{
    public static class RealNumberUtility
    {
        private static readonly Random random = new Random();

        public static double GenerateRandomRealNumber(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
