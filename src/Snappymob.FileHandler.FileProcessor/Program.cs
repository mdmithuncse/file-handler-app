// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snappymob.FileHandler.Service.ContentServices;

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

            using var host = builder.Build();
            var fileProcessManager = host.Services.GetRequiredService<IHostedService>() as FileProcessManager;

            if (fileProcessManager != null)
            {
                var cts = new CancellationTokenSource();

                await fileProcessManager.StartAsync(cts.Token);
                Console.WriteLine("StartAsync completed.");

                await fileProcessManager.StopAsync(cts.Token);
                Console.WriteLine("StopAsync completed.");
            }

            Environment.Exit(0);
        }
    }
}