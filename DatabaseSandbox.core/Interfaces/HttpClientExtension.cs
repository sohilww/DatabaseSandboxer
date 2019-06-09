using System.Net.Http;

namespace DatabaseSandbox.core.Interfaces
{
    public static class HttpClientExtension
    {
        public static void SetSandboxHeader(this HttpClient httpClient)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            databaseSandboxFacade
                .ExecuteSandbox(httpClient);
        }
        public static void SetSandboxHeader(this HttpRequestMessage httpRequestMessage)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            databaseSandboxFacade
                .ExecuteSandbox(httpRequestMessage);
        }

    }
}
