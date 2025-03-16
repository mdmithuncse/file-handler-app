using Snappymob.FileHandler.Common.Constants;

namespace Snappymob.FileHandler.Common.Utility
{
    public static class RandomObjectUtility
    {
        private static readonly Random random = new();

        public static string GenerateRandomObject()
        {
            int objectTypes = random.Next(ObjectConstants.Types.NumberOfObjectTypes);

            switch (objectTypes)
            {
                // Handle alphabetical string
                case 0:
                    return StringUtility.GenerateAlphabeticalString(random.Next(1, 100));

                // Handle alphanumeric string with spaces
                case 1:
                    return StringUtility.GenerateAlphanumericStringWithSpaces(random.Next(1, 100));

                // Handle integer string
                case 2:
                    return IntegerUtility.GenerateRandomInteger(int.MinValue, int.MaxValue).ToString();

                // Handle double string
                case 3:
                    return RealNumberUtility.GenerateRandomRealNumber(double.MinValue, double.MaxValue).ToString();

                default:
                    return string.Empty;
            }
        }
    }
}
