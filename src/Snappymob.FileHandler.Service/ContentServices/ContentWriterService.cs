namespace Snappymob.FileHandler.Service.ContentServices
{
    public class ContentWriterService : IContentWriterService
    {
        public void WriteContentToFile(string path, string content)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Unable to write content as path is empty or null.");

                    return;
                }

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("Unable to write content as content is empty or null.");

                    return;
                }

                File.WriteAllText(path, content);
            }

            catch (IOException ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}
