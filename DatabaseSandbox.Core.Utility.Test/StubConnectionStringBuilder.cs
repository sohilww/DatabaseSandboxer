﻿using DatabaseSandbox.Core.Database;

namespace DatabaseSandbox.Core.Utility
{
    public class StubConnectionStringBuilder : IConnectionStringBuilder
    {
        private string _connectionString;

        public StubConnectionStringBuilder()
        {
            _connectionString = @"data source=.\MSSQLSERVER2016;initial catalog=master;integrated security=true;";
        }
        public StubConnectionStringBuilder SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }
        public string Build()
        {
            return Build("master");
        }

        public string Build(string dbName)
        {
            return _connectionString.Replace("dbName",dbName);
        }

        public static IConnectionStringBuilder Create()
        {
            return new StubConnectionStringBuilder();
        }
        public static IConnectionStringBuilder CreateWithUserNameAndPassword()
        {
            return new StubConnectionStringBuilder()
                .SetConnectionString("Data source=.\\MSSQLSERVER2016;User Id=sa;password=123456;");
        }
    }
}