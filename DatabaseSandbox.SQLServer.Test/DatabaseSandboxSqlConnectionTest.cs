using System;
using System.Threading.Tasks;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Exceptions;
using DatabaseSandbox.Core.Utility;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.SQLServer.Test
{
    public class DatabaseSandboxSqlConnectionTest
    {
        private readonly SqlServerDbSandBoxConnection _sqlServerDbSandBoxConnection;

        public DatabaseSandboxSqlConnectionTest()
        {
            IConnectionStringBuilder connectionStringBuilder = new StubConnectionStringBuilder();
            _sqlServerDbSandBoxConnection =
                new SqlServerDbSandBoxConnection(connectionStringBuilder);
        }
        [Fact]
        public void open_connection_integratedSecurityConnection()
        {
            _sqlServerDbSandBoxConnection.Open();

        }
        [Fact]
        public async Task open_connect_with_integratedSecurityConnectionAsync()
        {
            await _sqlServerDbSandBoxConnection.OpenAsync();
        }
        [Fact]
        public void open_connection_with_userPassword_ConnectionString()
        {
            IConnectionStringBuilder connectionStringBuilder = new StubConnectionStringBuilder()
                .SetConnectionString("data source=.\\MSSQLSERVER2016;initial catalog=master;User Id=sa;Password=123456");
            var serverConnectionString =
                new SqlServerDbSandBoxConnection(connectionStringBuilder);

            serverConnectionString.Open();
        }
        [Fact]
        public void when_canNot_open_connection_to_database_should_throw_exception()
        {
            IConnectionStringBuilder connectionStringBuilder = new StubConnectionStringBuilder()
                .SetConnectionString("data source=.;initial catalog=master;User Id=sa;Password=123457");
            var serverConnectionString =
                new SqlServerDbSandBoxConnection(connectionStringBuilder);

            Action action=()=> serverConnectionString.Open();

            action.Should().Throw<CannotConnectToDatabaseException>();
        }
        [Fact]
        public async Task when_openAsync_canNot_open_connection_to_database_should_throw_exception()
        {
            //Todo: what should i do for CI server, is there any account!!!
            IConnectionStringBuilder connectionStringBuilder = new StubConnectionStringBuilder()
                .SetConnectionString("data source=.;initial catalog=master;User Id=sa;Password=123457");
            var serverConnectionString =
                new SqlServerDbSandBoxConnection(connectionStringBuilder);

            Func<Task> action =async () =>await serverConnectionString.OpenAsync();

            action.Should().Throw<CannotConnectToDatabaseException>();
        }

        [Fact]
        public void should_close_existing_connection()
        {
            _sqlServerDbSandBoxConnection.Open();

            _sqlServerDbSandBoxConnection.Close();
        }
    }
}