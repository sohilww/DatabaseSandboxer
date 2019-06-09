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
            return $"data source={_configuration.ConnectionString.DataSourcePath};" +
                   $"initial catalog={dbName};" +
                   $"integrated security=true; ";
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