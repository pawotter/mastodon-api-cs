using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Mastodon.API.Tests.Mocks
{
    class MockHttpClient
    {
        /// <summary>
        /// Will create an HttpClient using the MockHttpMessageHandler to force the client to ALWAYS return the
        /// same message.  Can be good for testing single calls to force certain execution paths without having
        /// to touch the real web server
        /// </summary>
        /// <param name="message">Message that will be returned in the response</param>
        /// <param name="statusCode">The standard HTTP Status Code that will be returned</param>
        /// <returns></returns>
        public static HttpClient Create(string message, HttpStatusCode statusCode)
        {
            return new HttpClient(new MockHttpMessageHandler(message, statusCode));
        }
    }
}
