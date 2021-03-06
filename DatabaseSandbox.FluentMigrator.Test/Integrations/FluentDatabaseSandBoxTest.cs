﻿using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using DatabaseSandbox.Core.Interfaces;
using DatabaseSandbox.Core.Utility;
using DatabaseSandbox.FluentMigrator.Config;
using DatabaseSandbox.FluentMigrator.Factory;
using DatabaseSandbox.FluentMigrator.Test.TestConstants;
using DatabaseSandbox.SQLServer;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test.Integrations
{
    public class FluentDatabaseSandBoxTest :IDisposable
    {
        private string _migrationDllPath;
        private SQLServerCreator _sqlServerDatabase;
        private string _databaseName;

        public FluentDatabaseSandBoxTest()
        {
            _sqlServerDatabase = new SQLServerCreator(StubConnectionStringBuilder.Create());
            _migrationDllPath = Directory.GetCurrentDirectory() + @"\MigratorFile\FluentMigrator.dll";
            CreateFluentMigratorHandler();
        }
        [Fact]
        public void when_call_sandbox_on_httpClient_should_create_database_and_set_header()
        {
            var httpClient = new HttpClient();

            var databaseInformation= httpClient.SetSandboxHeader();

            _databaseName = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseConnectionString).First();

            _databaseName.Should()
                .ExistDatabaseWithThatName(connectionString);
            _databaseName.Should().HaveSchema(connectionString);
            _databaseName.Should().BeSameAs(databaseInformation.DbName);
            connectionString.Should().BeSameAs(databaseInformation.ConnectionString);
        }

        [Fact]
        public void
            when_call_sandbox_on_httpClient_with_databaseName_should_generate_connectionString_and_must_not_create_database()
        {
            var httpClient=new HttpClient();
            var databaseName = DatabaseGenerator.NewName;
            CreateDatabase(databaseName);

            var databaseInformation = httpClient.SetSandboxHeader(databaseName);

            _databaseName = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.DefaultRequestHeaders
                .GetValues(HeaderNames.DatabaseConnectionString).First();

            _databaseName.Should().BeSameAs(databaseName);
            _databaseName.Should()
                .ExistDatabaseWithThatName(connectionString);
        }
        [Fact]
        public void
            when_call_sandbox_on_httpRequestMessage_with_databaseName_should_generate_connectionString_and_must_not_create_database()
        {
            var httpClient = new HttpRequestMessage();
            var databaseName = DatabaseGenerator.NewName;
            CreateDatabase(databaseName);

            var databaseInformation = httpClient.SetSandboxHeader(databaseName);

            _databaseName = httpClient.Headers
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.Headers
                .GetValues(HeaderNames.DatabaseConnectionString).First();

            _databaseName.Should().BeSameAs(databaseName);
            _databaseName.Should()
                .ExistDatabaseWithThatName(connectionString);
        }
        [Fact]
        public void when_call_sandbox_on_httpRequestMessage_should_create_database_and_set_header()
        {
            var httpClient = new HttpRequestMessage();
            var databaseInformation= httpClient.SetSandboxHeader();

            _databaseName = httpClient.Headers
                .GetValues(HeaderNames.DatabaseName).First();
            var connectionString = httpClient.Headers
                .GetValues(HeaderNames.DatabaseConnectionString).First();
            
            _databaseName.Should()
                .ExistDatabaseWithThatName(connectionString);
            _databaseName.Should().HaveSchema(connectionString);
            _databaseName.Should().BeSameAs(databaseInformation.DbName);
            connectionString.Should().BeSameAs(databaseInformation.ConnectionString);
        }
        private void CreateFluentMigratorHandler()
        {
            var configuration = CreateFluentMigratorConfiguration();
            FluentMigratorHandlerFactory.CreateAndConfigIOC(configuration);
        }
        private FluentMigratorConfiguration CreateFluentMigratorConfiguration()
        {
            var configuration = new FluentMigratorConfiguration()
            {
                MigrationClassLibraryPath = _migrationDllPath,
                SqlServerVersion = SQLServerVersions.Sql2012,
                ConnectionString = new SqlServerDbSandboxConnectionString
                {
                    DataSourcePath = @".\MSSQLSERVER2016",
                    IntegratedSecurity = true
                }
            };
            return configuration;
        }
        public void Dispose()
        {
            _sqlServerDatabase.Drop(_databaseName);
        }

        private void CreateDatabase(string databaseName)
        {
            _sqlServerDatabase.Create(databaseName);
        }
    }
}