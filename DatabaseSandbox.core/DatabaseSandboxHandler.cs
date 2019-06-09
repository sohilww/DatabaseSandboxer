using DatabaseSandbox.core.Configurations;

namespace DatabaseSandbox.core
{
    public interface IDatabaseSandboxHandler
    {
        CreatedDatabaseInformation Execute();
    }

    //Todo:priority 3: put where conditions
    public abstract class DatabaseSandboxHandler<TConfiguration> :IDatabaseSandboxHandler
        where TConfiguration : ISandBoxConfiguration
    {
        private readonly ISandBoxConfiguration _configuration;

        protected DatabaseSandboxHandler(ISandBoxConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract CreatedDatabaseInformation Execute();
    }
}