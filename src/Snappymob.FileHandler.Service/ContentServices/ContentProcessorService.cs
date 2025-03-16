using Snappymob.FileHandler.Common.Constants;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Snappymob.FileHandler.Service.ContentServices
{
    public class ContentProcessorService : IContentProcessorService
    {
        public void ProcessContent(string filePath, string content)
        {
            try
            {
                ValidateFile(filePath, content);

                string[] contentArray = content.Split(',');

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string item in contentArray)
                    {
                        if (string.IsNullOrWhiteSpace(item))
                            continue;

                        Tuple<string, string> result = ProcessObjectType(item);

                        writer.WriteLine($"Object: {result.Item1}, Type: {result.Item2}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        private void ValidateFile(string filePath, string content)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Unable to process content as file path is empty or null.");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Unable to process content as content is empty or null.");
            }
        }

        private Tuple<string, string> ProcessObjectType(string item)
        {
            string objectValue = item;
            string objectType = IdentifyObjectType(item);

            if (objectType == ObjectConstants.Types.Alphanumeric)
            {
                objectValue = item.Trim();
            }

            return new Tuple<string, string>(objectValue, objectType);
        }

        private static string IdentifyObjectType(string item)
        {
            if (IsInteger(item))
                return ObjectConstants.Types.Numerical;

            if (IsRealNumber(item))
                return ObjectConstants.Types.RealNumerical;

            if (IsAlphabetical(item))
                return ObjectConstants.Types.Alphabetical;

            if (IsAlphanumericWithSpaces(item))
                return ObjectConstants.Types.Alphanumeric;
                
            return ObjectConstants.Types.Unknown;
        }

        private static bool IsInteger(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return int.TryParse(input, out _);
        }

        private static bool IsRealNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return double.TryParse(input, out _);
        }

        private static bool IsAlphabetical(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false; // Or handle empty/null strings as needed
            }

            // Regular expression: ^[a-zA-Z\s]+$
            // ^: Matches the beginning of the string
            // [a-zA-Z]: Matches any uppercase or lowercase letter
            // \s: Matches any whitespace character (including spaces)
            // +: Matches one or more occurrences of the preceding character or group
            // $: Matches the end of the string

            return Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        }

        private static bool IsAlphanumericWithSpaces(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Regular expression: ^[a-zA-Z0-9\s]+$
            // ^: Matches the beginning of the string
            // [a-zA-Z0-9]: Matches any uppercase or lowercase letter or digit
            // \s: Matches any whitespace character (including spaces)
            // +: Matches one or more occurrences of the preceding character or group
            // $: Matches the end of the string

            return Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$");
        }
    }
}
