using System.Linq;
using System.Net.Http;
using DatabaseSandbox.core;
using DatabaseSandbox.core.Configurations;
using DatabaseSandbox.core.Interfaces;
using DatabaseSandbox.core.Utility;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class FluentDatabaseSandBoxTest
    {
        private string _connectionString = "data source=.;initial catalog=master;integrated security=true;";

        private string _migrationDllPath =
            @"F:\Project\PAP\DatabaseSandboxer\DatabaseSandbox.FluentMigrator.Test\MigratorFile\FluentMigrator.dll";

        private SqlServerDatabase _sqlServerDatabase;

        public FluentDatabaseSandBoxTest()
        {
            _sqlServerDatabase = new SqlServerDatabase(_connectionString);
        }
        [Fact]
        public void when_call_sandbox_on_httpClient_should_create_database_and_set_header()
        {
            var handler = CreateFluentMigratorHandler();
            DatabaseSandboxServiceLocator.RegisterService<IDatabaseSandboxHandler>(handler);
            var httpClient = new HttpClient();
            
            httpClient.SetSandboxHeader();

            httpClient.GetAsync("http://localhost:/hi").GetAwaiter().GetResult();

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
            var handler = CreateFluentMigratorHandler();
            DatabaseSandboxServiceLocator.RegisterService<IDatabaseSandboxHandler>(handler);
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
        private FluentMigratorHandler CreateFluentMigratorHandler()
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
            return new FluentMigratorHandler(configuration);
        }
    }
}