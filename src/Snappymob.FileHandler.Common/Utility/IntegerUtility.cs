namespace Snappymob.FileHandler.Common.Utility
{
    internal static class IntegerUtility
    {
        private static readonly Random random = new();

        internal static int GenerateRandomInteger(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
