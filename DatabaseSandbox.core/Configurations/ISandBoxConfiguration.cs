namespace DatabaseSandbox.core.Configurations
{
    public interface ISandboxConfiguration { }
    public interface ISandboxConfiguration<TConnectionString, TSeedDataConfiguration>
        : ISandboxConfiguration
        where TConnectionString : DbSandboxConnectionString
        where TSeedDataConfiguration : SeedDataScriptConfiguration

    {
        TConnectionString ConnectionString { set; get; }
        TSeedDataConfiguration SeedDataConfiguration { get; set; }
    }
}