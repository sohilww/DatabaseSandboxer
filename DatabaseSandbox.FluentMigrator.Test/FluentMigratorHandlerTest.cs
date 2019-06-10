using System;
using System.IO;
using DatabaseSandbox.core;
using DatabaseSandbox.core.Configurations;
using Xunit;
using DatabaseSandbox.FluentMigrator;
using FluentAssertions;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class FluentMigratorHandlerTest
    {
        private string _connectionString = "data source=.;initial catalog=master;integrated security=true;";

        private string _migrationDllPath;
            

        private readonly SqlServerDatabase _sqlServerDatabase;
        public FluentMigratorHandlerTest()
        {
            _sqlServerDatabase =new SqlServerDatabase(_connectionString);
            _migrationDllPath= Directory.GetCurrentDirectory()+ @"\MigratorFile\FluentMigrator.dll";
        }
        [Fact]
        public void when_execute_fluent_migration_should_create_database()
        {
            var configuration = new FluentMigratorConfiguration()
            {
                MigrationClassLibraryPath = _migrationDllPath,
                SqlServerVersion = SqlServerVersions.Sql2012,
                ConnectionString = new SqlServerDbSandboxConnectionString
                {
                    DataSourcePath = ".",
                    IntegratedSecurity = true
                }
            };
            var fluentMigratorHandler = new FluentMigratorHandler(configuration);

            var databaseInformation = fluentMigratorHandler.Execute();

            var dbExists = _sqlServerDatabase.IsExists(databaseInformation.DbName);
            dbExists.Should().BeTrue();

            _sqlServerDatabase.Drop(databaseInformation.DbName);
        }
    }
}
