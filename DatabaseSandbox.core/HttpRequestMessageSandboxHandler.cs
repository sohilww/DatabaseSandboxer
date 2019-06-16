using System.Net.Http;
using DatabaseSandbox.Core.Utility;

namespace DatabaseSandbox.Core
{
    internal class HttpRequestMessageSandboxHandler
    {
        internal void SetSandBoxHeader(HttpRequestMessage httpRequestMessage, CreatedDatabaseInformation databaseInformation)
        {
            httpRequestMessage.Headers
                .TryAddWithoutValidation(HeaderNames.DatabaseConnectionString, databaseInformation.ConnectionString);
            httpRequestMessage.Headers
                .TryAddWithoutValidation(HeaderNames.DatabaseName, databaseInformation.DbName);
        }
    }
}