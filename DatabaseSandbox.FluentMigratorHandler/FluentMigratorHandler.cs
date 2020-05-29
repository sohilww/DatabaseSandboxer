using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Utility;
using DatabaseSandbox.FluentMigrator.Config;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorHandler :
        DatabaseSandboxHandler<FluentMigratorConfiguration>
    {
        private readonly FluentMigratorConfiguration _configuration;
        private readonly IConnectionStringBuilder _connectionStringBuilder;
        private readonly DatabaseCreator _databaseCreator;
        private readonly ICommandExecutor _commandExecutor;

        public FluentMigratorHandler(FluentMigratorConfiguration configuration,
            IConnectionStringBuilder connectionStringBuilder,
            DatabaseCreator databaseCreator,
            ICommandExecutor commandExecutor)
            : base(configuration)
        {
            _configuration = configuration;
            _connectionStringBuilder = connectionStringBuilder;
            _databaseCreator = databaseCreator;
            _commandExecutor = commandExecutor;
        }
        public override CreatedDatabaseInformation Execute(string databaseName = null)
        {
            if (databaseName == null)
                databaseName = CreateNewDatabase();

            var newDbConnectionString = _connectionStringBuilder.Build(databaseName);

            var commandGenerator = new FluentMigratorCommandGenerator(_configuration);
            _commandExecutor.Execute(commandGenerator.GetCommand(newDbConnectionString));

            return new CreatedDatabaseInformation()
            {
                DbName = databaseName,
                ConnectionString = newDbConnectionString
            };
        }

        private string CreateNewDatabase()
        {
            string databaseName = DatabaseGenerator.NewName;
            _databaseCreator.Create(databaseName);
            return databaseName;

        }
    }
}
