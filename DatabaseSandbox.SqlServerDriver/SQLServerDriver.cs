
using System;
using System.Data.Common;
using System.Data.SqlClient;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.SQLServer
{
    public class SQLServerDriver: IDatabaseDriver
    {
        private readonly SqlConnection _connection;

        public SQLServerDriver(DbConnection connection)
        {
            _connection = (SqlConnection)connection;
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
                _connection.Close();
            }
            
        }

        private void Execute(string command)
        {
            _connection.Open();
            var sqlCommand = new SqlCommand(command, _connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
