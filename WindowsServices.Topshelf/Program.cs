

using Topshelf;
using WindowsServices.Topshelf;

HostFactory.Run(x =>
{
    x.Service<CustomService>();
    x.SetServiceName("TopshelfCustomService");
    x.SetDisplayName("TopshelfCustomService");
    x.SetDescription("Topshelf Custom Service");


    x.EnableServiceRecovery(config =>
    {
        config
        .RestartService(TimeSpan.FromSeconds(1))
        .RestartService(TimeSpan.FromSeconds(5))
        .RestartService(TimeSpan.FromSeconds(10));

        config.SetResetPeriod(1);
    });

    x.RunAsLocalSystem();
    x.StartAutomaticallyDelayed();
});