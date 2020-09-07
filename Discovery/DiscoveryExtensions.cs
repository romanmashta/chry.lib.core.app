using Autofac;

namespace Cherry.Lib.Core.App.Discovery
{
    public static class DiscoveryExtensions
    {
        public static void RegisterDiscovery<T>(this ContainerBuilder builder) where T : IDiscoveryService
            => builder.RegisterType<T>().As<IDiscoveryService>();
        
        public static void RegisterResolver<T>(this ContainerBuilder builder) where T : IResourceResolver
            => builder.RegisterType<T>().As<IResourceResolver>();        
    }
}