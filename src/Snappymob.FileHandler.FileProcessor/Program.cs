// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Service.ContentServices;
using Snappymob.FileHandler.Service.DirectoryServices;

namespace Snappymob.FileHandler.FileProcessor
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IContentReaderService, ContentReaderService>();
                    services.AddTransient<IContentProcessorService, ContentProcessorService>();
                    services.AddHostedService<FileProcessManager>();
                });

            await builder.RunConsoleAsync();
        }
    }
}