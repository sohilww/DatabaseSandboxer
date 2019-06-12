using System;
using DatabaseSandbox.Core.Test.TestConstants;
using DatabaseSandbox.Core.Utility;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Core.Test
{
    public class SqlServerDatabaseCreationTest:IDisposable
    {
        private string _connectionString;

        string _connectionstring =
            "data source=.;initial catalog=master;integrated security=true;";

        private SqlServerDatabase _database;

        public SqlServerDatabaseCreationTest()
        {
            _database = new SqlServerDatabase(_connectionstring);
        }

        [Fact]
        public void should_create_database_with_specific_name()
        {
            var databaseName = DatabaseGenerator.NewName;
            var result = _database.Create(databaseName);

            result.Should().BeTrue();

            DropDatabase(databaseName);
        }

        

        [Fact]
        public void should_drop_database_with_specific_name()
        {
            var databaseName = DatabaseGenerator.NewName;
            CreateDatabase(databaseName);

            
            Action act=()=> _database.Drop(databaseName);

            act.Should().NotThrow<Exception>();

        }

        private void CreateDatabase(string databaseName)
        {
            _database.Create(databaseName);
        }
        private void DropDatabase(string databaseName)
        {
            _database.Drop(databaseName);
        }

        public void Dispose()
        {
            _database?.Dispose();
        }
    }
}
