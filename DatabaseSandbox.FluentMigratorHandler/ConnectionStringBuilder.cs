using System.Data.SqlClient;

namespace DatabaseSandbox.FluentMigrator
{
    internal class ConnectionStringBuilder
    {
        private readonly FluentMigratorConfiguration _configuration;
        
        public ConnectionStringBuilder(FluentMigratorConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal string Build()
        {
            return Build("master");
        }

        internal string Build(string dbName)
        {
            var connectingStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = _configuration.ConnectionString.DataSourcePath,
                InitialCatalog = dbName,
                IntegratedSecurity = _configuration.ConnectionString.IntegratedSecurity
            };

            if (!connectingStringBuilder.IntegratedSecurity)
            {
                connectingStringBuilder.UserID = _configuration.ConnectionString.UserName;
                connectingStringBuilder.Password = _configuration.ConnectionString.Password;
            }
            return connectingStringBuilder.ConnectionString;
        }
    }
}