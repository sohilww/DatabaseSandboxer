namespace DatabaseSandbox.Core.Database
{
    public abstract class DatabaseCreator
    {
        protected DatabaseCreator(){}
        public abstract void Create(string databaseName);
        public abstract bool IsExists(string databaseName);
        public abstract void Drop(string databaseName);
    }
}
