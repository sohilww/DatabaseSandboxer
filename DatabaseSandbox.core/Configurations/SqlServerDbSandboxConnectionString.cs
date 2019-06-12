namespace DatabaseSandbox.Core.Configurations
{
    public class SqlServerDbSandboxConnectionString 
        : DbSandboxConnectionString
    {
        public bool IntegratedSecurity { get; set; }
    }
}