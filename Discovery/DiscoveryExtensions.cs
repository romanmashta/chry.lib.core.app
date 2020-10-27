using Autofac;
using Cherry.Lib.Core.Data.Models;

namespace Cherry.Lib.Core.App.Discovery
{
    public static class DiscoveryExtensions
    {
        public static void RegisterDiscovery<T>(this ContainerBuilder builder) where T : IDiscoveryService
            => builder.RegisterType<T>().As<IDiscoveryService>();
        
        public static void RegisterResolver<T>(this ContainerBuilder builder) where T : IResourceResolver
            => builder.RegisterType<T>().As<IResourceResolver>();
        
        public static void RegisterViewFor<V,T>(this ContainerBuilder builder) where T : IResourceView
            => builder.RegisterType<V>().As<IResourceView>();              
        
        public static string GetRef(this object entity) 
            => (entity as IObjectWithRef)?.Ref;            
    }
}