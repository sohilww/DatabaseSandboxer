using System.Net.Http;

namespace DatabaseSandbox.core
{
    public class HttpRequestMessageSandboxHandler
    {
        public void SetSandBoxHeader(HttpRequestMessage httpRequestMessage, string databaseName)
        {
            httpRequestMessage.Headers
                .TryAddWithoutValidation("databaseSandbox", databaseName);
        }
    }
}