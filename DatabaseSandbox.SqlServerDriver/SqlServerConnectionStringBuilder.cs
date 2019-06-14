using System.Data.SqlClient;
using DatabaseSandbox.Core.Database;

namespace DatabaseSandbox.SQLServer
{
    public class SqlServerConnectionStringBuilder:
        IConnectionStringBuilder
    {
        private readonly SqlServerDbSandboxConnectionString _connectionString;
        
        public SqlServerConnectionStringBuilder(SqlServerDbSandboxConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public string Build()
        {
            return Build("master");
        }

        public string Build(string dbName)
        {
            var connectingStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = _connectionString.DataSourcePath,
                InitialCatalog = dbName,
                IntegratedSecurity = _connectionString.IntegratedSecurity
            };

            if (!connectingStringBuilder.IntegratedSecurity)
            {
                connectingStringBuilder.UserID = _connectionString.UserName;
                connectingStringBuilder.Password = _connectionString.Password;
            }
            return connectingStringBuilder.ConnectionString;
        }
    }
}