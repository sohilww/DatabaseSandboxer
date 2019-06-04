using System.Net.Http;

namespace DatabaseSandbox.core.Interfaces
{
    public class DatabaseSandboxFacade
    {
        public void ExecuteSandbox(HttpClient httpClient,
            string connectionString,
            string databaseName,
            string migrationFilePath
            )
        {
            var fluentMigratorHandler = new FluentMigratorHandler();
            fluentMigratorHandler
                .Handle(connectionString,databaseName,migrationFilePath);

            var httpSandBoxHandler = new HttpSandBoxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpClient,connectionString);


        }
        public void ExecuteSandbox(HttpRequestMessage httpRequestMessage,
            string connectionString,
            string databaseName,
            string migrationFilePath
        )
        {
            var fluentMigratorHandler = new FluentMigratorHandler();
            fluentMigratorHandler
                .Handle(connectionString, databaseName, migrationFilePath);

            var httpSandBoxHandler = new HttpRequestMessageSandboxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpRequestMessage, connectionString);


        }
    }
}