using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.SQLServer
{
    public class SqlServerDbSandBoxConnection: IDbSandBoxConnection
    {
        private readonly SqlConnection _sqlConnection;

        public SqlServerDbSandBoxConnection(IConnectionStringBuilder connectionStringBuilder)
        {
            _sqlConnection = new SqlConnection(connectionStringBuilder.Build());
        }

        public void Open()
        {
            try
            {
                _sqlConnection.Open();
            }
            catch (SqlException exception)
            {
                throw new CannotConnectToDatabaseException(exception);
            }
            
        }

        public async Task OpenAsync()
        {
            try
            {
                await _sqlConnection.OpenAsync();
            }
            catch (SqlException exception)
            {
                throw new CannotConnectToDatabaseException(exception);
            }
        }
    }
}