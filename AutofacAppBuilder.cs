using System;
using System.Linq;
using Autofac;
using Autofac.Core;
using Cherry.Lib.Core.App.Extension;
using Serilog;

namespace Cherry.Lib.Core.App
{
    public class AutofacAppBuilder : AppBuilder
    {
        private ContainerBuilder _builder;
        
        internal AutofacAppBuilder(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public override void Configure()
        {
            Log.Information("Configure app with modules {@modules}", this.Modules.Select(t=>t.GetType().FullName).ToList());
            foreach (var module in Modules)
                _builder.RegisterModule((IModule) module);
            _builder.RegisterType<App>().AsSelf().SingleInstance();
        }

        public override App Build()
        {
            return null;
        }
    }
}