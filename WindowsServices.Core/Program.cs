

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WindowsServices.Microsoft;

 await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddHostedService<CustomService>())
    .UseWindowsService()
    .UseSystemd()
    .Build()
    .RunAsync();