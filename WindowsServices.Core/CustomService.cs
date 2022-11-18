using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServices.Microsoft
{
    public class CustomService : BackgroundService
    {
        private readonly string? _filename = "c:\\CustomService\\CoreService.txt";
        private Task WriteMessage(string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filename));
            return File.AppendAllTextAsync(_filename, message);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await WriteMessage("Starting...");

            while (!stoppingToken.IsCancellationRequested)
            {
                await WriteMessage("Working...");
                await Task.Delay(5000, stoppingToken);
            }
            await WriteMessage("Stopping...");
        }
    }
}
