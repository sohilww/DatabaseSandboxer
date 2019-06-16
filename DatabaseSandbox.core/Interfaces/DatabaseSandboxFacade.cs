using System.Net.Http;

namespace DatabaseSandbox.Core.Interfaces
{
    public class DatabaseSandboxFacade
    {
        public CreatedDatabaseInformation ExecuteSandbox(HttpClient httpClient)
        {
            var databaseInformation = ExecuteHandler();

            var httpSandBoxHandler = new HttpSandBoxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpClient,databaseInformation);
            return databaseInformation;
        }
        public CreatedDatabaseInformation ExecuteSandbox(HttpRequestMessage httpRequestMessage)
        {
            var databaseInformation = ExecuteHandler();

            var httpSandBoxHandler = new HttpRequestMessageSandboxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpRequestMessage, databaseInformation);
            return databaseInformation;
        }

        private CreatedDatabaseInformation ExecuteHandler()
        {
            var fluentMigratorHandler = DatabaseSandboxResolver.Current.Resolve<IDatabaseSandboxHandler>();
            var databaseInformation = fluentMigratorHandler.Execute();
            return databaseInformation;
        }
    }
}