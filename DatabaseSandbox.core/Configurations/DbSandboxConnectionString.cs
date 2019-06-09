namespace DatabaseSandbox.core.Configurations
{
    public class DbSandboxConnectionString
    {
        public string DataSourcePath { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class SqlServerDbSandboxConnectionString : DbSandboxConnectionString
    {
        public bool IntegratedSecurity { get; set; }
    }
}