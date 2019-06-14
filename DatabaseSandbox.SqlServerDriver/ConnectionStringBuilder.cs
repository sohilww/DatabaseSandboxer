using System.Data.SqlClient;

namespace DatabaseSandbox.SQLServer
{
    public class ConnectionStringBuilder
    {
        private readonly SqlServerDbSandboxConnectionString _connectionString;
        
        public ConnectionStringBuilder(SqlServerDbSandboxConnectionString connectionString)
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