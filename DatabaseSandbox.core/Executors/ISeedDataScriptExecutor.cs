using DatabaseSandbox.Core.Configurations;

namespace DatabaseSandbox.Core.Executors
{
    public interface ISeedDataScriptExecutor<T,DbConnection> where T:SeedDataScriptConfiguration
    {
        void Execute(DbConnection connection,T configuration);
    }
}