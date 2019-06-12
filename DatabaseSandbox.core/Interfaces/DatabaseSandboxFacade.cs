using System.Net.Http;

namespace DatabaseSandbox.Core.Interfaces
{
    public class DatabaseSandboxFacade
    {
        public void ExecuteSandbox(HttpClient httpClient)
        {
            var databaseInformation = ExecuteHandler();

            var httpSandBoxHandler = new HttpSandBoxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpClient,databaseInformation);
        }
        public void ExecuteSandbox(HttpRequestMessage httpRequestMessage)
        {
            var databaseInformation = ExecuteHandler();

            var httpSandBoxHandler = new HttpRequestMessageSandboxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpRequestMessage, databaseInformation);
        }

        private CreatedDatabaseInformation ExecuteHandler()
        {
            var fluentMigratorHandler = DatabaseSandboxServiceLocator.GetService<IDatabaseSandboxHandler>();
            var databaseInformation = fluentMigratorHandler.Execute();
            return databaseInformation;
        }
    }
}