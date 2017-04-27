using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using Mastodon.API.Tests.Mocks;


namespace Mastodon.API.Tests
{
    [TestFixture]
    public class ApiClientBaseTest
    {
        [Test]
        public void CreateUriTestWithIListParams()
        {
            var expected = new Uri("https://friends.nico/api/v1/path/to/endpoint?id[]=1&id[]=2&id[]=3");
            var baseUrl = new Uri("https://friends.nico/");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("id[]", "1"),
                new KeyValuePair<string, object>("id[]", "2"),
                new KeyValuePair<string, object>("id[]", "3")
            };
            var path = "/api/v1/path/to/endpoint";
            var actual = ApiClientBase.createUrl(baseUrl, path, parameters);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateUriTestWithIDictionary()
        {
            var expected = new Uri("https://friends.nico/api/v1/path/to/endpoint?id=hoge&arg1=fuga&arg2=piyo");
            var baseUrl = new Uri("https://friends.nico/");
            var parameters = new Dictionary<string, object>
            {
                { "id", "hoge" },
                { "arg1", "fuga" },
                { "arg2", "piyo" }
            };
            var path = "/api/v1/path/to/endpoint";
            var actual = ApiClientBase.createUrl(baseUrl, path, parameters);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateUriTestWithNoParams()
        {
            var expected = new Uri("https://friends.nico/api/v1/path/to/endpoint");
            var baseUrl = new Uri("https://friends.nico/");
            var path = "/api/v1/path/to/endpoint";
            var actual = ApiClientBase.createUrl(baseUrl, path, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateUriTestWithNoPath()
        {
            var expected = new Uri("https://friends.nico/");
            var baseUrl = new Uri("https://friends.nico/");
            var actual = ApiClientBase.createUrl(baseUrl, null, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async void GetAsyncWithStatusAndMessage()
        {
            var message = "Hello";
            var statusCode = HttpStatusCode.OK;
            var mockHttp = MockHttpClient.Create(message, statusCode);
            var apiClient = new ApiClientBase(new Uri("http://example.com/"), MockHttpClient.Create(message, statusCode));

            var response = await apiClient.GetAsync("/test");

            Assert.AreEqual(message, await response.Content.ReadAsStringAsync());
            Assert.AreEqual(statusCode, response.StatusCode);
        }
    }
}
