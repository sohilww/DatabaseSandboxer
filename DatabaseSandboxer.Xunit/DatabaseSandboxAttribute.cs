using System;
using System.Net.Http;
using System.Reflection;
using DatabaseSandbox.core;
using DatabaseSandbox.core.Interfaces;
using DatabaseSandbox.core.Utility;
using Xunit.Sdk;

namespace DatabaseSandboxer.Xunit
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = true)]
    public class DatabaseSandboxAttribute : BeforeAfterTestAttribute
    {
        private readonly HttpClient _httpClient;
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _migrationPath;
        
        public DatabaseSandboxAttribute(object httpClient,
            string connectionString,
            string databaseName,
            string migrationPath)
        {
            _httpClient = (HttpClient)httpClient;
            _connectionString = connectionString;
            _databaseName = databaseName;
            _migrationPath = migrationPath;
        }

        public DatabaseSandboxAttribute()
        {
            
        }

        public DatabaseSandboxAttribute
            (string connectionString,
            string migrationPath)
        {
            _databaseName = Database.NewName;
        }


        public override void Before(MethodInfo methodUnderTest)
        {
            _httpClient.SetSandboxHeader();
            
        }

        public override void After(MethodInfo methodUnderTest)
        {
            //
        }
    }
}
