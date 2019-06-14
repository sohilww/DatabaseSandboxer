using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.SQLServer.Test
{
    public class SQlServerConnectionStringBuilderTest
    {
        [Fact]
        public void should_create_connectionString_from_sqlServerConfiguration()
        {
            var connectionStringConfiguration=new SqlServerDbSandboxConnectionString()
            {
                DataSourcePath = ".",
                IntegratedSecurity = true
            };

            var connectionStringBuilder = new ConnectionStringBuilder(connectionStringConfiguration);
            var connectionString = connectionStringBuilder.Build();
            
            connectionString.Should().Contain("Data Source=.");
            connectionString.Should().Contain("Initial Catalog=master");
            connectionString.Should().Contain("Integrated Security=True");
        }

        [Fact]
        public void should_create_connectionString_with_userId_and_password()
        {
            var connectionStringConfiguration = new SqlServerDbSandboxConnectionString()
            {
                DataSourcePath = ".",
                UserName = "sa",
                Password = "123456",
            };

            var connectionStringBuilder = new ConnectionStringBuilder(connectionStringConfiguration);
            var connectionString = connectionStringBuilder.Build();

            connectionString.Should().Contain("Data Source=.");
            connectionString.Should().Contain("Initial Catalog=master");
            connectionString.Should().Contain("User ID");
            connectionString.Should().Contain("Password");
        }
    }
}