using DatabaseSandbox.Config;
using DatabaseSandbox.Core;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorDependencyConfig: IDatabaseSandboxComponentModule
    {
        public void Registry(IServiceRegistry serviceRegistry)
        {
            serviceRegistry
                .Register<FluentMigratorConfiguration>();
            serviceRegistry.
                Register(typeof(IDatabaseSandboxHandler),
                    typeof(FluentMigratorHandler));

            serviceRegistry.Register<ICommandExecutor,CommandExecutor>();
        }

        public static void AddToIOC(IServiceRegistry serviceRegistry)
        {
            var fluentMigratorDependencyConfig=new FluentMigratorDependencyConfig();
            fluentMigratorDependencyConfig.Registry(serviceRegistry);
        }
    }
}