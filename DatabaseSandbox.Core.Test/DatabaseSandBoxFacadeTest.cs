using System;
using System.Net.Http;
using DatabaseSandbox.core;
using DatabaseSandbox.Core.Test.TestConstants;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Core.Test
{
    public class DatabaseSandBoxFacadeTest:IDisposable
    {
        private readonly string _databaseName = Database.TestName;
        private readonly string _connectionString= "data source=.;initial catalog=master;integrated security=true";
        [Fact]
        public void when_call_execute_should_call_execute_flow()
        {
            var httpClient = new HttpClient();
            string migrationFilePath = PowerShellCommand.PathOfPowerShellFile;
            var facade=new DatabaseSandBoxFacade(); 

            Action action=()=> facade.ExecuteSandBox(httpClient,_databaseName,_connectionString,migrationFilePath);

            action.Should().NotThrow<Exception>();
        }

        public void Dispose()
        {
            var sqlDatabase=new SqlServerDatabase(_connectionString);
            sqlDatabase.Drop(_databaseName);
        }
    }
}