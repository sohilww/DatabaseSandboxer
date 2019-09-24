
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
        private bool _IsOwnerTheConnection;
        public SQLServerDriver(DbConnection connection,bool ownTheConnection=true)
        {
            _connection = (SqlConnection)connection;
            _IsOwnerTheConnection = ownTheConnection;
            OpenConnection();
        }

        public SQLServerDriver(string connectionString)
            : this(new SqlConnection(connectionString))
        {
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
            finally
            {
                CloseConnection();

            }

        }
        private void Execute(string command)
        {
            OpenConnection();
            var sqlCommand = new SqlCommand(command, _connection);
            sqlCommand.ExecuteNonQuery();
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

        private void OpenConnection()
        {
            if (_IsOwnerTheConnection)
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
        }
        private void CloseConnection()
        {
            if (_IsOwnerTheConnection)
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
        }

    }
}
