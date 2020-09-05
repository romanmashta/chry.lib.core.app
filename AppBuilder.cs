using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Cherry.Lib.Core.App.Extension;

namespace Cherry.Lib.Core.App
{
    public abstract class AppBuilder
    {
        public List<IModuleInfo> Modules { get; } = new List<IModuleInfo>();

        public static AppBuilder Create(ContainerBuilder builder) => new AutofacAppBuilder(builder);

        public AppBuilder UseModule(IModuleInfo moduleInfo)
        {
            Modules.Add(moduleInfo);
            return this;
        }

        public AppBuilder UseModule<T>() where T : IModuleInfo, new() => this.UseModule(new T());
       
        public abstract void Configure();

        public abstract App Build();
    }
}