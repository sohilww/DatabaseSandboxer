using System;
using Xunit;
using System.Data.SqlClient;
using DatabaseSandbox.Core.Exceptions;
using FluentAssertions;

namespace DatabaseSandbox.SQLServer.Test
{
    public class SqlServerDriverTest
    {
        string _connectionstring =
            "data source=.;initial catalog=master;integrated security=true;";
        [Fact]
        public void when_run_command_then_should_run_without_exception()
        {
            var sqlConnection = new SqlConnection(_connectionstring);
            var sqlServerDriver = new SQLServerDriver(sqlConnection);

            string sqlCommand = "use master;";

            Action action= ()=> sqlServerDriver.ExecuteCommand(sqlCommand);

            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void when_send_connectionString_should_connect_and_run_command()
        {
            var sqlServerDriver = new SQLServerDriver(_connectionstring);

            string sqlCommand = "use master;";

            Action action = () => sqlServerDriver.ExecuteCommand(sqlCommand);

            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void when_run_wrong_command_then_should_run_with_exception()
        {
            var sqlConnection=new SqlConnection(_connectionstring);
            var sqlServerDriver=new SQLServerDriver(sqlConnection);

            string wrongSqlCommand = "use";

            Action action = () => sqlServerDriver.ExecuteCommand(wrongSqlCommand);

            action.Should().Throw<DatabaseDriverException>();
        }

        [Fact]
        public void should_run_exists_command()
        {
            var sqlConnection=new SqlConnection(_connectionstring);
            var sqlServerDriver=new SQLServerDriver(sqlConnection,true);
            var commandText = "SELECT name FROM master.dbo.sysdatabases " +
                              $" WHERE name = 'master'";

            var isExists = sqlServerDriver.Exists(commandText);

            isExists.Should().BeTrue();
        }
    }
}
