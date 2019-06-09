using System.Net.Http;

namespace DatabaseSandbox.core.Interfaces
{
    public class DatabaseSandboxFacade
    {
        public void ExecuteSandbox(HttpClient httpClient)
        {
            var databaseInformation = ExecuteHandler();

            var httpSandBoxHandler = new HttpSandBoxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpClient,databaseInformation.ConnectionString);
        }
        public void ExecuteSandbox(HttpRequestMessage httpRequestMessage)
        {
            var databaseInformation = ExecuteHandler();

            var httpSandBoxHandler = new HttpRequestMessageSandboxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpRequestMessage, databaseInformation.ConnectionString);
        }

        private CreatedDatabaseInformation ExecuteHandler()
        {
            var fluentMigratorHandler = DatabaseSandboxServiceLocator.GetService<IDatabaseSandboxHandler>();
            var databaseInformation = fluentMigratorHandler.Execute();
            return databaseInformation;
        }
    }
}