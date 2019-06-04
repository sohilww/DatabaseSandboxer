using System;
using System.Net.Http;
using DatabaseSandbox.core;
using DatabaseSandbox.core.Interfaces;
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
            var facade=new DatabaseSandboxFacade(); 

            Action action=()=> facade.ExecuteSandbox(httpClient,_connectionString,_databaseName,migrationFilePath);

            action.Should().NotThrow<Exception>();
        }

        public void Dispose()
        {
            var sqlDatabase=new SqlServerDatabase(_connectionString);
            sqlDatabase.Drop(_databaseName);
        }
    }
}