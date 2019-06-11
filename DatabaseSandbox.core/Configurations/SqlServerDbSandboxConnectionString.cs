namespace DatabaseSandbox.core.Configurations
{
    public class SqlServerDbSandboxConnectionString 
        : DbSandboxConnectionString
    {
        public bool IntegratedSecurity { get; set; }
    }
}