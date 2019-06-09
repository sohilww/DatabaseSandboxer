using System;
using System.Net.Http;
using DatabaseSandbox.core.Utility;

namespace DatabaseSandbox.core
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