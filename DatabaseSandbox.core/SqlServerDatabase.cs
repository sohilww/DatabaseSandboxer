using System;
using System.Data.SqlClient;
namespace DatabaseSandbox.core
{
    public class SqlServerDatabase : DatabaseCreation, IDisposable
    {
        private SqlConnection _sqlConnection;

        public SqlServerDatabase(string connectionString):base(connectionString)
        {
            _sqlConnection = new SqlConnection(ConnectionString);
            _sqlConnection.Open();
        }
        public override bool Create(string databaseName)
        {

            if (IsExists(databaseName))
                Drop(databaseName);


            var command = new
                SqlCommand($"create database [{databaseName}]", _sqlConnection);

            command.ExecuteNonQuery();

            return true;


        }

        public override bool IsExists(string databaseName)
        {
            var commandText = "SELECT name FROM master.dbo.sysdatabases " +
                     $" WHERE name = '{databaseName}'";

            var existsCommand = new SqlCommand(commandText, _sqlConnection);
            var exist = existsCommand.ExecuteScalar();
            return exist != null;
        }

        public override bool Drop(string databaseName)
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