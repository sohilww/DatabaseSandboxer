﻿using System.Net.Http;

namespace DatabaseSandbox.core.Interfaces
{
    public static class HttpClientExtension
    {
        public static void SetSandBoxHeader(this HttpClient httpClient,
            string connectionString,
            string databaseName,
            string migrationPath)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            databaseSandboxFacade
                .ExecuteSandbox(httpClient,
                    connectionString,
                    databaseName,
                    migrationPath);
        }
        public static void SetSandBoxHeader(this HttpRequestMessage httpRequestMessage,
            string connectionString,
            string databaseName,
            string migrationPath)
        {
            var databaseSandboxFacade = new DatabaseSandboxFacade();
            databaseSandboxFacade
                .ExecuteSandbox(httpRequestMessage,
                    connectionString,
                    databaseName,
                    migrationPath);
        }

    }
}
