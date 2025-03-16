using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Common.Constants;
using Snappymob.FileHandler.Service.ContentServices;
using Snappymob.FileHandler.Service.DirectoryServices;

namespace Snappymob.FileHandler.FileCreator
{
    internal class FileCreateManager : IHostedService
    {
        private readonly ICheckDirectoryService _checkDirectoryService;
        private readonly ICreateDirectoryService _createDirectoryService;
        private readonly IContentCreatorService _contentCreatorService;
        private readonly IContentWriterService _contentWriterService;

        public FileCreateManager(ICheckDirectoryService checkDirectoryService,
            ICreateDirectoryService createDirectoryService,
            IContentCreatorService contentCreatorService,
            IContentWriterService contentWriterService)
        {
            _checkDirectoryService = checkDirectoryService;
            _createDirectoryService = createDirectoryService;
            _contentCreatorService = contentCreatorService;
            _contentWriterService = contentWriterService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello, This is file creator app! File creator app is starting.");

            string fileName = string.Concat(FileConstants.FileNames.InputFileName, FileConstants.Extensions.Txt);
            string directoryPath = DirectoryConstants.DirectoryPaths.OutputDirectoryPath;
            
            if (!_checkDirectoryService.CheckDirectory(directoryPath))
            {
                _createDirectoryService.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);
            string fileContent = _contentCreatorService.CreateContent(filePath);

            _contentWriterService.WriteContentToFile(filePath, fileContent);

            Console.WriteLine($"File {fileName} created successfully at: {filePath}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("File creator app is stopping.");

            return Task.CompletedTask;
        }
    }
}
