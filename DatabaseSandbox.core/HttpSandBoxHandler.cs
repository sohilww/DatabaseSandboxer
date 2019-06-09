using System.Net.Http;

namespace DatabaseSandbox.core
{
    public class HttpSandBoxHandler
    {
        public void SetSandBoxHeader(HttpClient httpClient,string connectionString)
        {
            httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation("databaseSandbox", connectionString);
        }
    }
}