using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Common.Constants;
using Snappymob.FileHandler.Service.ContentServices;

namespace Snappymob.FileHandler.FileProcessor
{
    internal class FileProcessManager : IHostedService
    {
        private readonly IContentReaderService _contentReaderService;
        private readonly IContentProcessorService _contentProcessorService;

        public FileProcessManager(IContentReaderService contentReaderService, 
            IContentProcessorService contentProcessorService)
        {
            _contentReaderService = contentReaderService;
            _contentProcessorService = contentProcessorService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello, This is file processor app! File processor app is starting.");

            string directoryPath = DirectoryConstants.DirectoryPaths.OutputDirectoryPath;
            
            string inputfile = string.Concat(FileConstants.FileNames.InputFileName, FileConstants.Extensions.Txt);     
            string inputFilePath = Path.Combine(directoryPath, inputfile);

            string outputfile = string.Concat(FileConstants.FileNames.OutputFileName, FileConstants.Extensions.Txt);
            string outputFilePath = Path.Combine(directoryPath, outputfile);

            string fileContent = _contentReaderService.ReadContentFromFile(inputFilePath);

            _contentProcessorService.ProcessContent(outputFilePath, fileContent);

            Console.WriteLine($"File {outputfile} created successfully at: {outputFilePath}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("File processor app is stopping.");

            return Task.CompletedTask;
        }
    }
}
