using System;
using DatabaseSandbox.core;
using DatabaseSandbox.core.Configurations;
using Xunit;
using DatabaseSandbox.FluentMigrator;
using FluentAssertions;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class FluentMigratorHandlerTest
    {
        [Fact]
        public void when_execute_fluent_migration_should_create_database()
        {
            
            var configuration=new FluentMigratorConfiguration()
            {
                MigrationClassLibraryPath= @"F:\Project\PAP\DatabaseSandboxer\DatabaseSandbox.FluentMigrator.Test\MigratorFile\FluentMigrator.dll",
                SqlServerVersion= "sqlserver2012",
                ConnectionString = new SqlServerDbSandboxConnectionString
                {
                    DataSourcePath = ".",
                    IntegratedSecurity = true
                }
            };
            var fluentMigratorHandler = new FluentMigratorHandler(configuration);

            var databaseInformation= fluentMigratorHandler.Execute();

            SqlServerDatabase sqlServerDatabase=
                new SqlServerDatabase("data source=.;initial catalog=master;integrated security=true;");

            var dbExists= sqlServerDatabase.IsExists(databaseInformation.DbName);

            dbExists.Should().BeTrue();

            sqlServerDatabase.Drop(databaseInformation.DbName);



        }
    }
}
