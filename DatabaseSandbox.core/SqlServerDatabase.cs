using System;
using System.Data.SqlClient;
namespace DatabaseSandbox.core
{
    public class SqlServerDatabase : DatabaseCreation, IDisposable
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public SqlServerDatabase(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
        }
        public bool Create(string databaseName)
        {

            if (IsExists(databaseName))
                Drop(databaseName);


            var command = new
                SqlCommand($"create database [{databaseName}]", _sqlConnection);

            command.ExecuteNonQuery();

            return true;


        }

        public bool IsExists(string databaseName)
        {
            var commandText = "SELECT name FROM master.dbo.sysdatabases " +
                     $" WHERE name = '{databaseName}'";

            var existsCommand = new SqlCommand(commandText, _sqlConnection);
            var exist = existsCommand.ExecuteScalar();
            return exist != null;
        }

        public bool Drop(string databaseName)
        {
            var commandText = $"Drop Database [{databaseName}]";
            var existsCommand = new SqlCommand(commandText, _sqlConnection);

            var exist = existsCommand.ExecuteScalar();

            return exist != null;
        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}