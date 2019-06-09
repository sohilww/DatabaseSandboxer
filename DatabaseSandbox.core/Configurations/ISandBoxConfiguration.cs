namespace DatabaseSandbox.core.Configurations
{
    public interface ISandBoxConfiguration { }
    public interface ISandBoxConfiguration<TConnectionString> :ISandBoxConfiguration
    {
        TConnectionString ConnectionString { set; get; }
    }
}