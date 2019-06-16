using DatabaseSandbox.Core.Configurations;

namespace DatabaseSandbox.Core
{
    public interface IDatabaseSandboxHandler
    {
        CreatedDatabaseInformation Execute();
    }

    public abstract class DatabaseSandboxHandler<TConfiguration> :IDatabaseSandboxHandler
        where TConfiguration : ISandboxConfiguration
    {
        private readonly ISandboxConfiguration _configuration;

        protected DatabaseSandboxHandler(ISandboxConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract CreatedDatabaseInformation Execute();
    }
}