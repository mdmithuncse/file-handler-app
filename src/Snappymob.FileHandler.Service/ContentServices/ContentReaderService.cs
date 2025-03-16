using Snappymob.FileHandler.Common.Constants;

namespace Snappymob.FileHandler.Service.ContentServices
{
    public class ContentReaderService : IContentReaderService
    {
        public string ReadContentFromFile(string path)
        {
			try
			{
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Unable to read content as file path is empty or null.");

                    return string.Empty;
                }

                return File.ReadAllText(path);
            }

			catch (IOException ex)
			{
                Console.WriteLine($"An error occured: {ex.Message}");

                return string.Empty;
            }
        }
    }
}
