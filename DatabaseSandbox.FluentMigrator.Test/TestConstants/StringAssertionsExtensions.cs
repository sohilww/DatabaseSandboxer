using System.Data.SqlClient;
using DatabaseSandbox.SQLServer;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace DatabaseSandbox.FluentMigrator.Test.TestConstants
{
    public static class StringAssertionsExtensions
    {
        public static AndConstraint<StringAssertions> 
            ExistDatabaseWithThatName(this StringAssertions assertions,
                string connectionString)
        {
            var databaseName= assertions.Subject;
            var sqlServerCreator=new SQLServerCreator(connectionString);
            var isExists= sqlServerCreator.IsExists(databaseName) 
                          && !string.IsNullOrEmpty(databaseName);

            Execute.Assertion.ForCondition(isExists).FailWith("database does not exists");
            return new AndConstraint<StringAssertions>(assertions);
        }

        public static AndConstraint<StringAssertions> HaveSchema(this StringAssertions assertions,
            string connectionString)
        {
            var dbName = assertions.Subject;
            SQLServerDriver driver=new SQLServerDriver(new SqlConnection(connectionString));
            var command = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'People'";
            var isTableCreated = driver.Exists(command);
            Execute.Assertion.ForCondition(isTableCreated)
                .FailWith("schema did not create correctly");
            return new AndConstraint<StringAssertions>(assertions);
        }
    }
}