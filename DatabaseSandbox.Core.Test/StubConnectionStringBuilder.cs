using DatabaseSandbox.Core.Database;

namespace DatabaseSandbox.Core.Utility
{
    public class StubConnectionStringBuilder : IConnectionStringBuilder
    {
        public string Build()
        {
            return "data source=.;initial catalog=master;integrated security=true;";
        }

        public string Build(string dbName)
        {
            return $"data source=.;initial catalog={dbName};integrated security=true;";
        }

        public static IConnectionStringBuilder Create()
        {
            return new StubConnectionStringBuilder();
        }
    }
}