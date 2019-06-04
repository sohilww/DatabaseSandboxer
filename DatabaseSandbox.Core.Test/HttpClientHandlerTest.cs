using System.Net.Http;
using DatabaseSandbox.core;
using DatabaseSandbox.Core.Test.TestConstants;
using FluentAssertions;
using Xunit;

namespace DatabaseSandbox.Core.Test
{
    public class HttpClientHandlerTest
    {
        [Fact]
        public void given_httpClient_when_call_SetSandBoxHeader_then_header_should_be_added_to_httpClient_object()
        {
            var handler=new HttpSandBoxHandler();
            var httpClient = new HttpClient();
            
            handler.SetSandBoxHeader(httpClient,HttpClientHeader.Value);
            
            httpClient.DefaultRequestHeaders.TryGetValues(HttpClientHeader.Name, out var values);
            values.Should().Contain(HttpClientHeader.Value);

        }
    }
}