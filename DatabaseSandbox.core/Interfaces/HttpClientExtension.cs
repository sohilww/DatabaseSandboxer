using System.Net.Http;

namespace DatabaseSandbox.Core.Interfaces
{
    public static class HttpClientExtension
    {
        public static CreatedDatabaseInformation SetSandboxHeader(this HttpClient httpClient,
            string databaseName = null)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            return databaseSandboxFacade
                .ExecuteSandbox(httpClient,databaseName);
        }
        public static CreatedDatabaseInformation SetSandboxHeader(this HttpRequestMessage httpRequestMessage,
            string databaseName=null)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            return databaseSandboxFacade
                .ExecuteSandbox(httpRequestMessage,databaseName);

        }

    }
}
