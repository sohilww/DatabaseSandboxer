namespace DatabaseSandbox.core
{
    public class FluentMigratorHandler
    {
        public void Handle(string connectionString, string databaseName,string migrationPath)
        {
            CreateDatabase(connectionString,databaseName);
            RunMigratorFile(migrationPath);
        }
        private void CreateDatabase(string connectionString,string databaseName)
        {
            var sqlServerDatabase=new SqlServerDatabase(connectionString);
            sqlServerDatabase.Create(databaseName);
        }
        private void RunMigratorFile(string migrationPath)
        {
            var powerShellHandler = new PowerShellHandler();
            powerShellHandler.Execute(migrationPath);
        }
    }
}