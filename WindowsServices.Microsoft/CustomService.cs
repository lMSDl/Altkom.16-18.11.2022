using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServices.Microsoft
{
    public class CustomService : ServiceBase
    {
        private Timer _timer;

        public void Start()
        {
            WriteMessage("Starting..");
            _timer = new Timer(Work, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        }
        protected override void OnStart(string[] args)
        {
            Start();
            base.OnStart(args);
        }

        public void Stop()
        {
            WriteMessage("Stopping..");
        }
        protected override void OnStop()
        {
            Stop();
            base.OnStop();
        }

        private void Work(object? state)
        {
            WriteMessage("Working...");
        }

        private readonly string? _filename = "c:\\CustomService\\MicrosoftService.txt";
        private void WriteMessage(string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filename));
            File.AppendAllText(_filename, message + "\n");
        }
    }
}
