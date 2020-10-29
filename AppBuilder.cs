using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Cherry.Lib.Core.App.Extension;
using Cherry.Lib.Core.Identity.Clients.Contracts;
using Serilog;

namespace Cherry.Lib.Core.App
{
    public class AppBuilder
    {
        private ContainerBuilder _builder;

        private string _applicationName;
        private string _logoUrl;
        private string _appHeaderUrl;
        private string _appIcon;

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
        
        public AppBuilder WithName(string applicationName)
        {
            _applicationName = applicationName;
            return this;
        }
        
        public AppBuilder WithLogoFromModule<T>(string logoImage) where T: AppModule
        {
            _logoUrl = $"/_content/{typeof(T).Assembly.GetName().Name}{logoImage}";
            return this;
        }
        
        public AppBuilder WithLogoUrl(string logoImage)
        {
            _logoUrl = logoImage;
            return this;
        }
        
        public AppBuilder WithAppHeader(string logoImage)
        {
            _appHeaderUrl = logoImage;
            return this;
        }                   
        
        public AppBuilder UseModule<T>() where T : IModuleInfo, new() => this.UseModule(new T());

        public void Configure()
        {
            Log.Information("Configure app with modules {@modules}", this.Modules.Select(t=>t.GetType().FullName).ToList());
            foreach (var module in Modules)
                _builder.RegisterModule((IModule) module);
            _builder.Register((IComponentContext context)=>
            {
                var modules = context.Resolve<IEnumerable<AppModule>>();
                Log.Information("Creating app with name {0} and logo {1}", _applicationName, _logoUrl);
                return new App(modules, context.Resolve<IAuthenticationClientService>())
                {
                    ApplicationName = _applicationName,
                    Icon = _appIcon,
                    LogoUrl = _logoUrl,
                    AppHeaderUrl=_appHeaderUrl
                };
            }).As<App>().AsSelf().SingleInstance();            
        }

        public AppBuilder WithIcon(string icon)
        {
            _appIcon = icon;
            return this;
        }
    }
}