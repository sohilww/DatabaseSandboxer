using DatabaseSandbox.Config;
using DatabaseSandbox.Core.Database;

namespace DatabaseSandbox.SQLServer
{
    public class SQLServerDependecyConfig : IDatabaseSandboxComponentModule
    {
        public void Registry(IServiceRegistry serviceRegistry)
        {
             serviceRegistry.Register<DatabaseCreator, SQLServerCreator>();
             serviceRegistry.Register<IDatabaseDriver, SQLServerDriver>();
        }
    }
}