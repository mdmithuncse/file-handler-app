namespace Snappymob.FileHandler.Common.Utility
{
    internal static class RealNumberUtility
    {
        private static readonly Random random = new();

        internal static double GenerateRandomRealNumber(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
