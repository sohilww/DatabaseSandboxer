using System.Data.Common;

namespace DatabaseSandbox.Core.Database
{
    public abstract class DatabaseCreator
    {
        protected DatabaseCreator(){}

        protected DatabaseCreator(DbConnection dbConnection)
        {

        }

        public abstract void Create(string databaseName);
        public abstract bool IsExists(string databaseName);
        public abstract void Drop(string databaseName);
    }
}
