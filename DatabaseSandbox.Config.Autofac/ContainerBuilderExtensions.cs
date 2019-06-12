using Autofac;

namespace DatabaseSandbox.Config.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static IServiceRegistry
            CreateServiceRegistry(this ContainerBuilder containerBuilder)
        {
            var autofacModule = new DatabaseSandboxAutofacModule(containerBuilder);
            return autofacModule.Registry();
        }

        public static IResolver CreateResolver(this ContainerBuilder containerBuilder)
        {
            var scope = containerBuilder.Build().BeginLifetimeScope();
            var resolver = new AutofacResolver(scope);
            return resolver;
        }
    }

}