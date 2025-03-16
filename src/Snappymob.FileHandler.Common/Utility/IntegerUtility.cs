namespace Snappymob.FileHandler.Common.Utility
{
    public static class IntegerUtility
    {
        private static readonly Random random = new Random();

        public static int GenerateRandomInteger(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
