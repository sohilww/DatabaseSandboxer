namespace DatabaseSandbox.core
{
    public abstract class DatabaseCreator
    {
        protected readonly string ConnectionString;

        protected DatabaseCreator(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract bool Create(string databaseName);
        public abstract bool IsExists(string databaseName);
        public abstract bool Drop(string databaseName);
    }
}
