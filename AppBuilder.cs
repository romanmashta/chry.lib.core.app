using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Cherry.Lib.Core.App.Extension;
using Serilog;

namespace Cherry.Lib.Core.App
{
    public class AppBuilder
    {
        private ContainerBuilder _builder;
        
        public List<IModuleInfo> Modules { get; } = new List<IModuleInfo>();

        public static AppBuilder Create(ContainerBuilder builder) => new AppBuilder(builder);
        
        internal AppBuilder(ContainerBuilder builder)
        {
            _builder = builder;
        }        

        public AppBuilder UseModule(IModuleInfo moduleInfo)
        {
            Modules.Add(moduleInfo);
            return this;
        }

        public AppBuilder UseModule<T>() where T : IModuleInfo, new() => this.UseModule(new T());

        public void Configure()
        {
            Log.Information("Configure app with modules {@modules}", this.Modules.Select(t=>t.GetType().FullName).ToList());
            foreach (var module in Modules)
                _builder.RegisterModule((IModule) module);
            _builder.RegisterType<App>().AsSelf().SingleInstance();            
        }
    }
}