using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Configurations;
using DatabaseSandbox.Core.Interfaces;
using DatabaseSandbox.Core.Utility;
using DatabaseSandbox.FluentMigrator.Factory;
using DatabaseSandbox.SQLServer;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test.Integrations
{
    public class FluentDatabaseSandBoxTest :IDisposable
    {
        private string _connectionString = "data source=.;initial catalog=master;integrated security=true;";

        private string _migrationDllPath;
        private SQLServerCreator _sqlServerDatabase;
        private string _databaseName;

        public FluentDatabaseSandBoxTest()
        {
            _sqlServerDatabase = new SQLServerCreator(_connectionString);
            _migrationDllPath = Directory.GetCurrentDirectory() + @"\MigratorFile\FluentMigrator.dll";
        }
        [Fact]
        public void when_call_sandbox_on_httpClient_should_create_database_and_set_header()
        {
            CreateFluentMigratorHandler();

            var httpClient = new HttpClient();

            httpClient.SetSandboxHeader();

            _databaseName = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseConnectionString).First();
            var dbExists = _sqlServerDatabase.IsExists(_databaseName);

            var driver = new SQLServerDriver(new SqlConnection(connectionString));
            var command = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES " +
            "WHERE TABLE_NAME = 'People') SELECT 1";
            var tableExists= driver.Exists(command);
            tableExists.Should().BeTrue();
            _databaseName.Should().NotBeNullOrEmpty();
            connectionString.Should().NotBeNullOrEmpty();
            dbExists.Should().BeTrue();
        }
        [Fact]
        public void when_call_sandbox_on_httpRequestMessage_should_create_database_and_set_header()
        {
            CreateFluentMigratorHandler();

            var httpClient = new HttpRequestMessage();
            httpClient.SetSandboxHeader();

            _databaseName = httpClient.Headers
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.Headers
                .GetValues(HeaderNames.DatabaseConnectionString).First();
            var dbExists = _sqlServerDatabase.IsExists(_databaseName);
            _databaseName.Should().NotBeNullOrEmpty();
            connectionString.Should().NotBeNullOrEmpty();
            dbExists.Should().BeTrue();
        }


        private FluentMigratorHandler CreateFluentMigratorHandler()
        {
            var configuration = CreateFluentMigratorConfiguration();
            var handler = FluentMigratorHandlerFactory.Create(configuration);
            return handler;
        }
        private FluentMigratorConfiguration CreateFluentMigratorConfiguration()
        {
            var configuration = new FluentMigratorConfiguration()
            {
                MigrationClassLibraryPath = _migrationDllPath,
                SqlServerVersion = SQLServerVersions.Sql2012,
                ConnectionString = new SqlServerDbSandboxConnectionString
                {
                    DataSourcePath = ".",
                    IntegratedSecurity = true
                }
            };
            return configuration;
        }

        public void Dispose()
        {
            _sqlServerDatabase.Drop(_databaseName);
        }
    }
}