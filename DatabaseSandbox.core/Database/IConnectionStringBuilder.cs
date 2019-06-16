using DatabaseSandbox.Core.Configurations;

namespace DatabaseSandbox.Core.Database
{
    public interface IConnectionStringBuilder
    {
        string Build();
        string Build(string dbName);
    }
}