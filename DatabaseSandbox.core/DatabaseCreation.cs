namespace DatabaseSandbox.core
{
    public abstract class DatabaseCreation
    {
        protected readonly string ConnectionString;

        protected DatabaseCreation(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract bool Create(string databaseName);
        public abstract bool IsExists(string databaseName);
        public abstract bool Drop(string databaseName);
    }
}
