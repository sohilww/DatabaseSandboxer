using Autofac;
using DatabaseSandbox.Config.Autofac;
using DatabaseSandbox.Core;
using DatabaseSandbox.FluentMigrator.Config;
using DatabaseSandbox.SQLServer;

namespace DatabaseSandbox.FluentMigrator.Factory
{
    public class FluentMigratorHandlerFactory
    {
        public static FluentMigratorHandler CreateAndConfigIOC(FluentMigratorConfiguration config)
        {
            var containerBuilder = new ContainerBuilder();
            var serviceRegistry = containerBuilder.CreateServiceRegistry();

            FluentMigratorDependencyConfig.AddToIOC(serviceRegistry);

            serviceRegistry.Register<FluentMigratorConfiguration>(config);
            serviceRegistry.Register<SqlServerDbSandboxConnectionString>(config.ConnectionString);

            var serverDependecyConfig = new SQLServerDependecyConfig();
            serverDependecyConfig.Registry(serviceRegistry);

            var resolver = containerBuilder.CreateResolver();

            var handler = resolver.Resolve<IDatabaseSandboxHandler>();
            DatabaseSandboxResolver.SetResolver(resolver);
            return (FluentMigratorHandler)handler;
        }
    }
}