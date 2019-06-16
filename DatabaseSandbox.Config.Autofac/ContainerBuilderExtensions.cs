using Autofac;

namespace DatabaseSandbox.Config.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static IServiceRegistry
            CreateServiceRegistry(this ContainerBuilder containerBuilder)
        {
            var autofacModule = new DatabaseSandboxIocAutofacModule(containerBuilder);
            return autofacModule.Registry();
        }

        public static IResolver CreateResolver(this ContainerBuilder containerBuilder)
        {
            RegisterResolver(containerBuilder);

            var scope = containerBuilder.Build()
                .BeginLifetimeScope();  
            var resolver = scope.Resolve<IResolver>();
            return resolver;
        }

        private static void RegisterResolver(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AutofacResolver>()
                .As<IResolver>()
                .SingleInstance();
        }
    }

}