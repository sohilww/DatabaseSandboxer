using System.Net.Http;
using DatabaseSandbox.core.Utility;

namespace DatabaseSandbox.core
{
    public class HttpSandBoxHandler
    {
        public void SetSandBoxHeader(HttpClient httpClient,CreatedDatabaseInformation databaseInformation)
        {
            httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation(HeaderNames.DatabaseConnectionString, databaseInformation.ConnectionString);
            httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation(HeaderNames.DatabaseName, databaseInformation.DbName);
        }
    }
}