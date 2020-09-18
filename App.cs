using System.Collections.Generic;
using System.Linq;
using Autofac;
using Cherry.Lib.Core.App.Extension;
using Serilog;

namespace Cherry.Lib.Core.App
{
    public class App
    {
        public string ApplicationName { get; set; }
        public string LogoUrl { get; set; }
        public List<AppModule> Modules { get; } = new List<AppModule>();
        public string AppHeaderUrl { get; set; }
        public string Icon { get; set; }

        public App(IEnumerable<AppModule> modules)
        {
            Log.Information("Instantiating app with modules {@modules}", modules.Select(m=>m.GetType().FullName));
            Modules.AddRange(modules);
        }

        public void Start()
        {
            Log.Information("Starting app");

            foreach (var module in Modules)
            {
                module.Start();
            }
        }
        
        public void Stop()
        {
            Log.Information("Stopping app");
            foreach (var module in Modules)
            {
                module.Stop();
            }
        }
    }
}