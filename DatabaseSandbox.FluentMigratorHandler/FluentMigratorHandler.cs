using System;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Utility;
using DatabaseSandbox.SQLServer;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorHandler :
        DatabaseSandboxHandler<FluentMigratorConfiguration>
    {
        private readonly FluentMigratorConfiguration _configuration;
        private ConnectionStringBuilder _connectionStringBuilder;

        public FluentMigratorHandler(FluentMigratorConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            _connectionStringBuilder = new ConnectionStringBuilder(_configuration);
        }
        public override CreatedDatabaseInformation Execute()
        {
            var databaseName= CreateNewDatabase(_connectionStringBuilder);
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

        private string CreateNewDatabase(ConnectionStringBuilder connectionStringBuilder)
        {
            string databaseName = DatabaseGenerator.NewName;
            var masterconnectionString = connectionStringBuilder.Build();
            var sqlServer = new SQLServerCreator(masterconnectionString);
            sqlServer.Create(databaseName);
            return databaseName;

        }
    }
}
