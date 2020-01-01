using DatabaseSandbox.Config;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.SQLServer;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorDependencyConfig: IDatabaseSandboxComponentModule
    {
        public void Registry(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.
                Register(typeof(IDatabaseSandboxHandler),
                    typeof(FluentMigratorHandler));

            
            serviceRegistry.Register<ICommandExecutor,PowerShellHandler>();
            serviceRegistry.Register<IConnectionStringBuilder,
                SqlServerConnectionStringBuilder>();

            serviceRegistry.Register<DatabaseCreator,SQLServerCreator>();

            serviceRegistry.Register<IDbSandBoxConnection, SqlServerDbSandBoxConnection>();
        }

        public static void AddToIOC(IServiceRegistry serviceRegistry)
        {
            var fluentMigratorDependencyConfig=new FluentMigratorDependencyConfig();
            fluentMigratorDependencyConfig.Registry(serviceRegistry);
        }
    }
}