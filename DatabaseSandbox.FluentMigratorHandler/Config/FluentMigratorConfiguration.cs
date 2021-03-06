﻿using DatabaseSandbox.Core.Configurations;
using DatabaseSandbox.SQLServer;

namespace DatabaseSandbox.FluentMigrator.Config
{
    public class FluentMigratorConfiguration : 
        ISandboxConfiguration<SqlServerDbSandboxConnectionString, SeedDataScriptConfiguration>
    {
        public SqlServerDbSandboxConnectionString ConnectionString { get; set; }
        public SeedDataScriptConfiguration SeedDataConfiguration { get; set; }
        public string MigrationClassLibraryPath { get; set; }
        public string SqlServerVersion { get; set; }
    }
}