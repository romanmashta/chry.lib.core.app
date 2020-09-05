using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Serilog;

namespace Cherry.Lib.Core.App.Extension
{
    public class AppModule
    {
        private string ModuleName => this.GetType().FullName;
        
        public AppModule()
        {
        }
        
        public virtual void Start()
        {
            Log.Information("Starting module {@module}", ModuleName);
        }
        
        public virtual void Stop()
        {
            Log.Information("Stopping module {@module}", ModuleName);
        }
    }
}