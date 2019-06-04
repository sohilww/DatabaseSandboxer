using System.Net.Http;

namespace DatabaseSandbox.core
{
    public class HttpSandBoxHandler
    {
        public void SetSandBoxHeader(HttpClient httpClient,string databaseName)
        {
            httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation("databaseSandbox", databaseName);
        }
    }
}