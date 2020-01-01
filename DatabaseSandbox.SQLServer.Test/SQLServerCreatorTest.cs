using System;
using System.Threading.Tasks;
using DatabaseSandbox.Core.Exceptions;
using DatabaseSandbox.Core.Utility;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.SQLServer.Test
{
    public class SQLServerCreatorTest
    {
        private SQLServerCreator _database;

        public SQLServerCreatorTest()
        {
            _database = new SQLServerCreator(StubConnectionStringBuilder.Create());
        }

        [Fact]
        public void should_create_database_with_specific_name()
        {
            var databaseName = DatabaseGenerator.NewName;

            Action action = () => _database.Create(databaseName);

            action.Should().NotThrow<Exception>();

            var databaseExists = _database.IsExists(databaseName);
            databaseExists.Should().BeTrue();

            DropDatabase(databaseName);
        }

        [Fact]
        public void given_wrong_name_then_should_not_create_database()
        {
            var wrongDatabaseName = "";

            Action action = () => _database.Create(wrongDatabaseName);

            action.Should().Throw<DatabaseCreationException>();
        }

        [Fact]
        public void when_run_concurrency_command_should_execute_all_commands()
        {
            var connectionString = StubConnectionStringBuilder.Create();
            
            Parallel.For(0, 20, (i) =>
            {
                var sqlServerCreator = new SQLServerCreator(connectionString);
                var databaseName = DatabaseGenerator.NewName;

                sqlServerCreator.Create(databaseName);

                sqlServerCreator.Drop(databaseName);
            });
            
        }
        [Fact]
        public void drop_exists_database()
        {
            var databaseName = DatabaseGenerator.NewName;
            CreateDatabase(databaseName);

            _database.Drop(databaseName);

            var databaseExists = CheckDatabaseExists(databaseName);

            databaseExists.Should().BeFalse();
        }

        private bool CheckDatabaseExists(string databaseName)
        {
            return _database.IsExists(databaseName);
        }

        private void CreateDatabase(string databaseName)
        {
            _database.Create(databaseName);
        }

        private void DropDatabase(string databaseName)
        {
            _database.Drop(databaseName);
        }
    }
}