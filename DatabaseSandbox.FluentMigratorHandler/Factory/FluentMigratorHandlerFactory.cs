using Autofac;
using DatabaseSandbox.Config.Autofac;
using DatabaseSandbox.Core;

namespace DatabaseSandbox.FluentMigrator.Factory
{
    public class FluentMigratorHandlerFactory
    {
        public static FluentMigratorHandler Create(FluentMigratorConfiguration config)
        {
            var containerBuilder = new ContainerBuilder();
            var serviceRegistry = containerBuilder.CreateServiceRegistry();

            FluentMigratorDependencyConfig.AddToIOC(serviceRegistry);
            var resolver = containerBuilder.CreateResolver();

            var handler = resolver.Resolve<IDatabaseSandboxHandler>();

            return (FluentMigratorHandler)handler;
        }
    }
}