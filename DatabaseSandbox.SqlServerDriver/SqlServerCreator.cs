﻿using System;
using System.Data;
using System.Data.SqlClient;
using DatabaseSandbox.Core.Database;
using DatabaseSandbox.Core.Exceptions;

namespace DatabaseSandbox.SQLServer
{
    public class SQLServerCreator : DatabaseCreator
    {
        private SqlConnection _sqlConnection;
        public SQLServerCreator(IConnectionStringBuilder connectionStringBuilder)
        {
            _sqlConnection = new SqlConnection(connectionStringBuilder.Build());
            
        }
        public override void Create(string databaseName)
        {
            try
            {
                ExecuteCreateDatabase(databaseName);
            }
            catch (Exception exception)
            {
                throw new DatabaseCreationException(exception.Message);
            }
        }

        private void ExecuteCreateDatabase(string databaseName)
        {
            if (IsExists(databaseName))
                Drop(databaseName);
            
            try
            {
                _sqlConnection.Open();
                CreateDatabase(databaseName);
            }
            catch (Exception exception)
            {
                throw new DatabaseCreationException(exception.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
            
        }

        private void CreateDatabase(string databaseName)
        {
            var command = new
                SqlCommand($"create database [{databaseName}]", _sqlConnection);
            command.ExecuteNonQuery();
        }

        public override bool IsExists(string databaseName)
        {
            try
            {
                _sqlConnection.Open();
                return CheckDatabaseIsExists(databaseName);
            }
            catch (Exception exception)
            {
                 throw new DatabaseCreationException(exception.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        private bool CheckDatabaseIsExists(string databaseName)
        {
            var commandText = "SELECT name FROM master.dbo.sysdatabases " +
                              $" WHERE name = '{databaseName}'";

            var existsCommand = new SqlCommand(commandText, _sqlConnection);
            var exist = existsCommand.ExecuteScalar();
            return exist != null;
            
        }

        public override void Drop(string databaseName)
        {
            try
            {
                _sqlConnection.Open();
                CloseConnectionsOfDatabases(databaseName);
                var commandText = $"Drop Database [{databaseName}]";
                var existsCommand = new SqlCommand(commandText, _sqlConnection);
                existsCommand.ExecuteScalar();
                
            }
            catch (Exception exception)
            {
                throw new DatabaseCreationException(exception.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }

        }
        private void CloseConnectionsOfDatabases(string databaseName)
        {
            var commandText = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            var existsCommand = new SqlCommand(commandText, _sqlConnection);
            existsCommand.ExecuteNonQuery();
        }

        public void Dispose()
        {
            if (_sqlConnection.State != ConnectionState.Closed)
                _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}