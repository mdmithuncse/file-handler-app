namespace Snappymob.FileHandler.Service.DirectoryServices
{
    public class CreateDirectoryService : ICreateDirectoryService
    {
        public void CreateDirectory(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Unable to create directory as path is empty or null.");

                    return;
                }

                Directory.CreateDirectory(path);
            }

            catch (IOException ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}
