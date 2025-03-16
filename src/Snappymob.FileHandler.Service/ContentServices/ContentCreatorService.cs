using Snappymob.FileHandler.Common.Constants;
using Snappymob.FileHandler.Common.Utility;
using System.Text;

namespace Snappymob.FileHandler.Service.ContentServices
{
    public class ContentCreatorService : IContentCreatorService
    {
        public string CreateContent(string filePath)
        {
			try
			{
				if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("Unable to create content as file path is empty or null.");

                    return string.Empty;
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    long currentFileSize = 0;

                    while (currentFileSize < FileConstants.Size.MaxFileSize)
                    {
                        string randomObject = RandomObjectUtility.GenerateRandomObject();
                        writer.Write(randomObject + ",");

                        currentFileSize += Encoding.UTF8.GetByteCount(randomObject);
                    }
                }

                return File.ReadAllText(filePath).TrimEnd(',');
            }

			catch (IOException ex)
			{
                Console.WriteLine($"An error occured: {ex.Message}");

                return string.Empty;
            }
        }
    }
}
