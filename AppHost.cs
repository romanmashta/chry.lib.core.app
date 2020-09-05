using System;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Cherry.Lib.Core.App
{
    public abstract class AppHost
    {
        protected abstract void Init(string[] args);
        protected abstract Task Execute();
        
        private Action<AppBuilder> _configureApp;

        public AppHost(Action<AppBuilder> configureApp = null)
        {
            _configureApp = configureApp;
        }

        private void InitLogger()
        {
            var levelSwitch = new LoggingLevelSwitch();
            var builder = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch);
            ConfigureLogger(builder);
            Log.Logger = builder.CreateLogger();
        }

        private void PreInit()
        {
            InitLogger();
        }

        protected virtual void ConfigureLogger(LoggerConfiguration configuration)
        {
        }
        
        protected virtual void ConfigureServices(IServiceCollection services)
        {
            Log.Information("Configure Services");
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));
        }
        
        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            Log.Information("Configure Container");
            builder.RegisterInstance(Log.Logger);
            
            var appBuilder = AppBuilder.Create(builder);
            _configureApp?.Invoke(appBuilder);
            appBuilder.Configure();
        }
        
        public async Task Run(string[] args)
        {
            PreInit();
            
            Log.Information("Init host {@Host}", this.GetType().FullName);
            Init(args);
            
            Log.Information("Executing host");
            await Execute();
            
            Log.Information("Host shutdown");
        }
    }
}