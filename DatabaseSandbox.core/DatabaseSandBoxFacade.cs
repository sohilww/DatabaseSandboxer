using System.Net.Http;

namespace DatabaseSandbox.core
{
    public class DatabaseSandBoxFacade
    {
        public void ExecuteSandBox(HttpClient httpClient,
            string databaseName,
            string connectionString,
            string migrationFilePath
            )
        {
            var fluentMigratorHandler = new FluentMigratorHandler();
            fluentMigratorHandler
                .Handle(connectionString,databaseName,migrationFilePath);

            var httpSandBoxHandler = new HttpSandBoxHandler();
            httpSandBoxHandler.SetSandBoxHeader(httpClient,connectionString);


        }
    }
}