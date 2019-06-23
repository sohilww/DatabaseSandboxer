using System.Net.Http;

namespace DatabaseSandbox.Core.Interfaces
{
    public class DatabaseSandboxFacade
    {
        public CreatedDatabaseInformation ExecuteSandbox(HttpClient httpClient, 
            string databaseName=null)
        {
            var databaseInformation = ExecuteHandler(databaseName);

            var httpSandBoxHandler = new HttpSandBoxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpClient,databaseInformation);
            return databaseInformation;
        }
        public CreatedDatabaseInformation ExecuteSandbox(HttpRequestMessage httpRequestMessage,
            string databaseName=null)
        {
            var databaseInformation = ExecuteHandler(databaseName);

            var httpSandBoxHandler = new HttpRequestMessageSandboxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpRequestMessage, databaseInformation);
            return databaseInformation;
        }

        private CreatedDatabaseInformation ExecuteHandler(string databaseName=null)
        {
            var fluentMigratorHandler = DatabaseSandboxResolver.Current.Resolve<IDatabaseSandboxHandler>();
            var databaseInformation = fluentMigratorHandler.Execute(databaseName);
            return databaseInformation;
        }
    }
}