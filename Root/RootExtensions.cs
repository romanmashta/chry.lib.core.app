using Autofac;

namespace Cherry.Lib.Core.App.Root
{
    public static class RootExtensions
    {
        public static void RegisterRootView<T>(this ContainerBuilder builder)
        {
            builder.RegisterType<RootViewProvider<T>>().As<IRootViewProvider>();
        }
    }
}