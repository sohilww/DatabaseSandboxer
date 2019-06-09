using DatabaseSandbox.core;
using DatabaseSandbox.core.Configurations;

namespace DatabaseSandbox.FluentMigrator
{
    public class FluentMigratorConfiguration : ISandBoxConfiguration<SqlServerDbSandboxConnectionString>
    {
        public SqlServerDbSandboxConnectionString ConnectionString { get; set; }
        public string MigrationClassLibraryPath { get; set; }
        public string SqlServerVersion { get; set; }
    }
}