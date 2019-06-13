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
    internal class FluentMigratorCommandGenerator
    {
        private readonly FluentMigratorConfiguration _configuration;
        private readonly string _databaseName;

        internal FluentMigratorCommandGenerator(FluentMigratorConfiguration configuration, string databaseName)
        {
            _configuration = configuration;
            _databaseName = databaseName;
        }
        //Todo:priority 5 separate command building
        internal string GetCommand(string newDbConnectionString)
        {
            return $"dotnet fm migrate -p {_configuration.SqlServerVersion} -c " +
                   $"\"{newDbConnectionString} \" " +
                   $"-a \"{_configuration.MigrationClassLibraryPath}\""; ;



        }

    }
}