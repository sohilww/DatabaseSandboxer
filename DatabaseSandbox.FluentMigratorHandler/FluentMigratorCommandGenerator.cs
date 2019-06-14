using DatabaseSandbox.FluentMigrator.Config;

namespace DatabaseSandbox.FluentMigrator
{
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