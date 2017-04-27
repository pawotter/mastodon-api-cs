using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Mastodon.API.Tests.Mocks
{
    class MockHttpMessageHandler : HttpClientHandler
    {
        private readonly HttpResponseMessage _response;

        public MockHttpMessageHandler(string message, HttpStatusCode statusCode)
        {
            _response = new HttpResponseMessage()
            {
                Content = new StringContent(message),
                StatusCode = statusCode
            };
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult<HttpResponseMessage>(_response);
        }
    }
}
