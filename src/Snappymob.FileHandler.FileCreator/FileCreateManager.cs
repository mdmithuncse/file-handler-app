using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Service.RandomObject;

namespace Snappymob.FileHandler.FileCreator
{
    internal class FileCreateManager : IHostedService
    {
        private readonly IRandomObjectService _randomObjectService;

        public FileCreateManager(IRandomObjectService randomObjectService)
        {
            _randomObjectService = randomObjectService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello, This is file creator app! File creator app is starting.");

            string randomObject = _randomObjectService.GenerateRandomObject();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("File creator app is stopping.");

            return Task.CompletedTask;
        }
    }
}
