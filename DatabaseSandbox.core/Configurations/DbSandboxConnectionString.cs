namespace DatabaseSandbox.core.Configurations
{
    public abstract class DbSandboxConnectionString
    {
        public string DataSourcePath { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class SeedDataScriptConfiguration
    {
        public string Path { get; set; }
    }
}