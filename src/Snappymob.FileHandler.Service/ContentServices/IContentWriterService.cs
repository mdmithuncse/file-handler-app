namespace Snappymob.FileHandler.Service.ContentServices
{
    public interface IContentWriterService
    {
        void WriteContentToFile(string path, string content);
    }
}
