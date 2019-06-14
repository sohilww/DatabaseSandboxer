using DatabaseSandbox.Core.Configurations;

namespace DatabaseSandbox.SQLServer
{
    public class SqlServerDbSandboxConnectionString 
        : DbSandboxConnectionString
    {
        public bool IntegratedSecurity { get; set; }
    }
}