using DatabaseSandbox.FluentMigrator;
using Xunit;

namespace DatabaseSandbox.FluentMigrator.Test
{
    public class FluentMigratorHandlerTest
    {
        [Fact]
        public void Test1()
        {
            var fluentMigratorHandler=new FluentMigratorHandler(null);
        }
    }
}
