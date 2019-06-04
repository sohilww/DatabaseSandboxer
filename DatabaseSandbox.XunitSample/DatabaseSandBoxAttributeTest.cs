using System.Net.Http;
using DatabaseSandbox.core.Interfaces;
using DatabaseSandbox.core.Utility;
using DatabaseSandboxer.Xunit;
using Xunit;

namespace DatabaseSandbox.XunitSample
{
    public class DatabaseSandBoxAttributeTest
    {
        [Fact]
        [DatabaseSandbox]
        public void you_can_see_the_usage_of_databaseSandboxAttribute()
        {
            var httpClient=new HttpClient();

            
        }
    }
}