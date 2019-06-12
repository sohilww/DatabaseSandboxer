using System;
using System.Linq;
using Xunit;
namespace DatabaseSandbox.SQLServer.Test
{
    public class SqlServerDriverTest
    {
        [Fact]
        public void when_request_for_open_conneciton_should_connected_to_database()
        {
            var sqlServerDriver=new SQLServerDriver();
        }
    }
}
