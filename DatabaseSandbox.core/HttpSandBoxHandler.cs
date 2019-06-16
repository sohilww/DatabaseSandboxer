using System.Net.Http;
using DatabaseSandbox.Core.Utility;

namespace DatabaseSandbox.Core
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