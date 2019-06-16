using System.Net.Http;

namespace DatabaseSandbox.Core.Interfaces
{
    public static class HttpClientExtension
    {
        public static CreatedDatabaseInformation SetSandboxHeader(this HttpClient httpClient)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            return databaseSandboxFacade
                .ExecuteSandbox(httpClient);
        }
        public static CreatedDatabaseInformation SetSandboxHeader(this HttpRequestMessage httpRequestMessage)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            return databaseSandboxFacade
                .ExecuteSandbox(httpRequestMessage);

        }

    }
}
