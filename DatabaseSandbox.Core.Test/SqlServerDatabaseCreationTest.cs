using System;
using DatabaseSandbox.core;
using DatabaseSandbox.Core.Test.TestConstants;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Core.Test
{
    public class SqlServerDatabaseCreationTest:IDisposable
    {
        private string _connectionString;

        string _databaseName =
            "databaseTest";
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
            var result = _database.Create(Database.TestName);

            result.Should().BeTrue();
        }

        [Fact]
        public void should_drop_database_with_specific_name()
        {
            var databaseName = Database.TestName;
            CreateDatabase(databaseName);

            
            Action act=()=> _database.Drop(databaseName);

            act.Should().NotThrow<Exception>();

        }

        private void CreateDatabase(string databaseName)
        {
            _database.Create(databaseName);
        }


        public void Dispose()
        {
            _database?.Dispose();
        }
    }
}
