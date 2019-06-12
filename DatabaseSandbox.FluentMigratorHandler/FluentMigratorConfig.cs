using DatabaseSandbox.Config;
using DatabaseSandbox.core;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorConfig: IDatabaseSandboxComponentModule
    {
        public void Registry(IServiceRegistry serviceRegistry)
        {
            serviceRegistry
                .Register<FluentMigratorConfiguration>();
            serviceRegistry.
                Register(typeof(IDatabaseSandboxHandler),
                    typeof(FluentMigratorHandler));
        }

        public static void AddToIOC(IServiceRegistry serviceRegistry)
        {
            var f=new FluentMigratorConfig();
            f.Registry(serviceRegistry);
        }
    }
}