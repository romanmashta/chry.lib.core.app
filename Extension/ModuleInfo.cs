using Autofac;
using Serilog;

namespace Cherry.Lib.Core.App.Extension
{
    public interface IModuleInfo
    {
        
    }
    
    public abstract class ModuleInfo<T> : Module, IModuleInfo where T : AppModule
    {
        protected sealed override void Load(ContainerBuilder builder)
        {
            Log.Information("Register Services for module {@module}", typeof(T).FullName);            
            builder.RegisterType<T>().AsSelf().As<AppModule>().SingleInstance();
            RegisterServices(builder);
        }

        public virtual void RegisterServices(ContainerBuilder builder)
        {
        }
    }
}