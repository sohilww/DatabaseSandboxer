﻿using DatabaseSandbox.core;
using System;
using DatabaseSandbox.core.Utility;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorHandler : DatabaseSandboxHandler<FluentMigratorConfiguration>
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
            var command = commandGenerator.GetCommand(newDbConnectionString);

            var powerShellHandler = new PowerShellHandler();
            powerShellHandler.Execute(command,databaseName);

            return new CreatedDatabaseInformation()
            {
                DbName = databaseName,
                ConnectionString = newDbConnectionString
            };
        }

        private string CreateNewDatabase(ConnectionStringBuilder connectionStringBuilder)
        {
            string databaseName = Database.NewName;
            var masterconnectionString = connectionStringBuilder.Build();
            var sqlServer = new SqlServerDatabase(masterconnectionString);
            sqlServer.Create(databaseName);
            return databaseName;

        }
    }
}
