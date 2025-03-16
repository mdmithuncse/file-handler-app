// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Service.ContentServices;
using Snappymob.FileHandler.Service.DirectoryServices;

namespace Snappymob.FileHandler.FileCreator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ICheckDirectoryService, CheckDirectoryService>();
                    services.AddTransient<ICreateDirectoryService, CreateDirectoryService>();
                    services.AddTransient<IContentCreatorService, ContentCreatorService>();
                    services.AddTransient<IContentWriterService, ContentWriterService>();
                    services.AddHostedService<FileCreateManager>();
                });

            await builder.RunConsoleAsync();
        }
    }
}