namespace Snappymob.FileHandler.Service.DirectoryServices
{
    public class CheckDirectoryService : ICheckDirectoryService
    {
        public bool CheckDirectory(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Directory path is empty or null.");

                    return false;
                }

                if (Directory.Exists(path))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");

                return false;
            }
        }
    }
}
