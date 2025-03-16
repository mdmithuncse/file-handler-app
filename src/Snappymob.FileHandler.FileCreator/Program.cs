// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Service.RandomObject;

namespace Snappymob.FileHandler.FileCreator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IRandomObjectService, RandomObjectService>();
                    services.AddHostedService<FileCreateManager>();
                });

            await builder.RunConsoleAsync();
        }
    }
}