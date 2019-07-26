
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.SQLServer
{
    public class SQLServerDriver : IDatabaseDriver
    {
        private readonly SqlConnection _connection;

        public SQLServerDriver(DbConnection connection)
        {
            _connection = (SqlConnection)connection;
        }

        public SQLServerDriver(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public void ExecuteCommand(string command)
        {
            try
            {
                Execute(command);
            }
            catch (Exception exception)
            {
                throw new DatabaseDriverException(exception.Message);
            }

        }

        public bool Exists(string command)
        {
            try
            {
                OpenConnection();
                var sqlCommand = new SqlCommand(command, _connection);
                var result = sqlCommand.ExecuteScalar();
                return result != null;
            }
            catch (Exception exception)
            {
                throw new DatabaseDriverException(exception);
            }
            finally
            {
                _connection.Close();
            }
        }
        private void Execute(string command)
        {
            OpenConnection();
            var sqlCommand = new SqlCommand(command, _connection);
            sqlCommand.ExecuteNonQuery();
        }
        private void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }
    }
}
