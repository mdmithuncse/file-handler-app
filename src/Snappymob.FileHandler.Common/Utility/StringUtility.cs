namespace Snappymob.FileHandler.Common.Utility
{
    internal static class StringUtility
    {
        private static readonly Random random = new();

        internal static string GenerateAlphabeticalString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal static string GenerateAlphanumericStringWithSpaces(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            const int maxSpaces = 10;

            string alphanumeric = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            int leadingSpaces = random.Next(1, maxSpaces);
            int trailingSpaces = random.Next(1, maxSpaces);

            return new string(' ', leadingSpaces) + alphanumeric + new string(' ', trailingSpaces);
        }
    }
}
