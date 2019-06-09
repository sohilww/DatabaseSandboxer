using System.Net.Http;

namespace DatabaseSandbox.core
{
    public class HttpRequestMessageSandboxHandler
    {
        public void SetSandBoxHeader(HttpRequestMessage httpRequestMessage, string connectionString)
        {
            httpRequestMessage.Headers
                .TryAddWithoutValidation("databaseSandbox", connectionString);
        }
    }
}