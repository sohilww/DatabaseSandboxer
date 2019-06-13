using System.IO;
using System.Linq;
using System.Net.Http;
using DatabaseSandbox.Core;
using DatabaseSandbox.Core.Configurations;
using DatabaseSandbox.Core.Interfaces;
using DatabaseSandbox.Core.Utility;
using DatabaseSandbox.FluentMigrator.Factory;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class FluentDatabaseSandBoxTest
    {
        private string _connectionString = "data source=.;initial catalog=master;integrated security=true;";

        private string _migrationDllPath;
        private SqlServerDatabase _sqlServerDatabase;

        public FluentDatabaseSandBoxTest()
        {
            _sqlServerDatabase = new SqlServerDatabase(_connectionString);
            _migrationDllPath = Directory.GetCurrentDirectory() + @"\MigratorFile\FluentMigrator.dll";
        }
        [Fact]
        public void when_call_sandbox_on_httpClient_should_create_database_and_set_header()
        {
            var handler = CreateFluentMigratorHandler();
            DatabaseSandboxServiceLocator.RegisterService<IDatabaseSandboxHandler>(handler);
            var httpClient = new HttpClient();

            httpClient.SetSandboxHeader();

            var databaseName = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseConnectionString).First();
            var dbExists = _sqlServerDatabase.IsExists(databaseName);

            databaseName.Should().NotBeNullOrEmpty();
            connectionString.Should().NotBeNullOrEmpty();
            dbExists.Should().BeTrue();
            
            _sqlServerDatabase.Drop(databaseName);
        }
        [Fact]
        public void when_call_sandbox_on_httpRequestMessage_should_create_database_and_set_header()
        {
            var config = CreateFluentMigratorConfiguration();
            var handler = FluentMigratorHandlerFactory.Create(config);
            
            var httpClient = new HttpRequestMessage();
            httpClient.SetSandboxHeader();

            var databaseName = httpClient.Headers
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.Headers
                .GetValues(HeaderNames.DatabaseConnectionString).First();
            var dbExists = _sqlServerDatabase.IsExists(databaseName);
            databaseName.Should().NotBeNullOrEmpty();
            connectionString.Should().NotBeNullOrEmpty();
            dbExists.Should().BeTrue();

            _sqlServerDatabase.Drop(databaseName);
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
    }
}