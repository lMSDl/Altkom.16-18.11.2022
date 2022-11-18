﻿

using System.ServiceProcess;
using WindowsServices.Microsoft;

var service = new CustomService();

if(Environment.UserInteractive)
{
    service.Start();

    Console.ReadLine();

    service.Stop();
}
else
    ServiceBase.Run(service);