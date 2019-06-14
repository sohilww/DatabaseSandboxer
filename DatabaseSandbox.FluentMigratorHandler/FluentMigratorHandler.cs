using System;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Utility;
using DatabaseSandbox.FluentMigrator.Config;
using DatabaseSandbox.SQLServer;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorHandler :
        DatabaseSandboxHandler<FluentMigratorConfiguration>
    {
        private readonly FluentMigratorConfiguration _configuration;
        private IConnectionStringBuilder _connectionStringBuilder;
        private readonly DatabaseCreator _databaseCreator;

        public FluentMigratorHandler(FluentMigratorConfiguration configuration,
            IConnectionStringBuilder connectionStringBuilder,
            DatabaseCreator databaseCreator)
            :base(configuration)
        {
            _configuration = configuration;
            _connectionStringBuilder = connectionStringBuilder;
            _databaseCreator = databaseCreator;
        }
        public override CreatedDatabaseInformation Execute()
        {
            var databaseName= CreateNewDatabase();
            var newDbConnectionString = _connectionStringBuilder.Build(databaseName);

            var commandGenerator = new FluentMigratorCommandGenerator(_configuration,databaseName);
            var commandExecutor=new PowerShellHandler();

            commandExecutor.Execute(commandGenerator.GetCommand(_connectionStringBuilder.Build(databaseName)));

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
