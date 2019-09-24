using System.Data.SqlClient;
using System.IO;
using System.Net;
using DatabaseSandbox.Core.Configurations;
using DatabaseSandbox.Core.Executors;

namespace DatabaseSandbox.SQLServer
{
    public class SqlServerSeedDataExecutor : ISeedDataScriptExecutor<SeedDataScriptConfiguration,SqlConnection>
    {
        public void Execute(SqlConnection connection, SeedDataScriptConfiguration configuration)
        {
            var command = ReadFile(configuration.Path);
            var sqlDriver=new SQLServerDriver(connection,false);
            sqlDriver.ExecuteCommand(command);
        }

        private string ReadFile(string scriptPath)
        {
            var command= File.ReadAllText(scriptPath);
            return command;
        }
    }
}