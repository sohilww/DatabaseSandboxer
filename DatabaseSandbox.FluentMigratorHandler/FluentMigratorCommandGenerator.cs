using DatabaseSandbox.FluentMigrator.Config;

namespace DatabaseSandbox.FluentMigrator
{
    internal class FluentMigratorCommandGenerator
    {
        private readonly FluentMigratorConfiguration _configuration;
        
        internal FluentMigratorCommandGenerator(FluentMigratorConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Todo:priority 5 separate command building
        internal string GetCommand(string newDbConnectionString)
        {
            return $"dotnet fm migrate -p {_configuration.SqlServerVersion} -c " +
                   $"\"{newDbConnectionString} \" " +
                   $"-a \"{_configuration.MigrationClassLibraryPath}\"";
        }

    }
}