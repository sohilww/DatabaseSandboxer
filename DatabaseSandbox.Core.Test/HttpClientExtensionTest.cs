using System.Net.Http;
using DatabaseSandbox.core;
using DatabaseSandbox.Core.Test.TestConstants;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Core.Test
{
    public class HttpClientExtensionTest
    {
        [Fact]
        public void given_httpClient_when_call_SetSandBoxHeader_then_header_should_be_added_to_httpClient_object()
        {
            var httpClient = new HttpClient();
            
            httpClient.SetSandBoxHeader(HttpClientHeader.Value);

            httpClient.DefaultRequestHeaders.TryGetValues(HttpClientHeader.Name, out var values);
            values.Should().Contain(HttpClientHeader.Value);

        }
    }
}