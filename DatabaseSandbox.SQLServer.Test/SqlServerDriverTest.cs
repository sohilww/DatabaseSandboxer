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

            string sqlcommand = "use master;";

            Action action= ()=> sqlServerDriver.ExecuteCommand(sqlcommand);
        }

        [Fact]
        public void when_run_wrong_command_then_should_run_without_exception()
        {
            var sqlConneciton=new SqlConnection(_connectionstring);
            var sqlServerDriver=new SQLServerDriver(sqlConneciton);

            string wrongSqlCommand = "use";

            Action action = () => sqlServerDriver.ExecuteCommand(wrongSqlCommand);

            action.Should().Throw<DatabaseDriverException>();
        }
    }
}
