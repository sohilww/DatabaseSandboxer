using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using DatabaseSandbox.Core.Configurations;
using DatabaseSandbox.Core.Utility;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.SQLServer.Test
{
    public class SeedDataScriptExecutorTest:IDisposable
    {
        private string _connectionString = "data source=.\\MSSQLSERVER2016;initial catalog=master;integrated security=true;";
        private string _commandFilePath;
        private string _databaseName;
        private SqlConnection _connection;

        public SeedDataScriptExecutorTest()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }
        [Fact]
        public void should_run_script_file_on_database()
        {
            _commandFilePath = CreateCommandFilePath();
            _databaseName = CreateSqlServerCommandFile(_commandFilePath);

            var seedDataConfiguration = new SeedDataScriptConfiguration()
            {
                Path = _commandFilePath
            };

            var sqlServerScriptDataExecutor = new SqlServerSeedDataExecutor();
            sqlServerScriptDataExecutor.Execute(_connection, seedDataConfiguration);

            IsCommandRunSuccessfully();
        }

        private static string CreateCommandFilePath()
        {
            return $"{Guid.NewGuid()}.sql";
        }

        private void IsCommandRunSuccessfully()
        {
            var checkCommand = "SELECT name FROM master.dbo.sysdatabases " +
                               $" WHERE name = '{_databaseName}'";
            TheCommandRunWasSuccessful(checkCommand).Should().BeTrue();
        }

        private string CreateSqlServerCommandFile(string path)
        {
            var databaseName = DatabaseGenerator.NewName;
            string command = $"Create Database [{databaseName}]";
            using (StreamWriter streamWriter=new StreamWriter(path,true))
            {
                streamWriter.WriteLine(command);
            }
            return databaseName;
        }

        private bool TheCommandRunWasSuccessful(string command)
        {
            var sqlCommand = new SqlCommand(command, _connection);
            var result = sqlCommand.ExecuteScalar();
            return result != null;
        }

        private void DeleteDatabase()
        {
            var deleteDatabase = $"drop database [{_databaseName}]";
            var sqlCommand = new SqlCommand(deleteDatabase, _connection);
            sqlCommand.ExecuteNonQuery();
        }
        public void Dispose()
        {
            File.Delete(_commandFilePath);
            DeleteDatabase();
            _connection.Close();
        }
    }
}