using System.Data;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.SQLServer.Test
{
    public class SQlServerConnectionStringBuilderTest
    {
        [Fact]
        public void should_create_connectionString_from_sqlServerConfiguration()
        {
            var connectionStringConfiguration = new SqlServerDbSandboxConnectionString()
            {
                DataSourcePath = ".",
                IntegratedSecurity = true
            };

            var connectionStringBuilder = new SqlServerConnectionStringBuilder(connectionStringConfiguration);
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

            var connectionStringBuilder = new SqlServerConnectionStringBuilder(connectionStringConfiguration);
            var connectionString = connectionStringBuilder.Build();

            connectionString.Should().Contain("Data Source=.");
            connectionString.Should().Contain("Initial Catalog=master");
            connectionString.Should().Contain("User ID");
            connectionString.Should().Contain("Password");
        }

        [Fact]
        public void should_create_connectionString_when_send_dbName()
        {
            const string dbName = "dbName";
            string expectedInitialCatalog = $"Initial Catalog={dbName}";
            var connectionStringConfiguration = new SqlServerDbSandboxConnectionString()
            {
                DataSourcePath = ".",
                UserName = "sa",
                Password = "1234546"
            };
            var connectionStringBuilder = new SqlServerConnectionStringBuilder(connectionStringConfiguration);


            var connectionString = connectionStringBuilder.Build(dbName);

            connectionString.Should().Contain("Data Source=.");
            connectionString.Should().Contain(expectedInitialCatalog);
            connectionString.Should().Contain("User ID");
            connectionString.Should().Contain("Password");

        }
    }
}