using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
            var actual = ApiClientBase.CreateUrl(baseUrl, path, parameters);
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
            var actual = ApiClientBase.CreateUrl(baseUrl, path, parameters);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateUriTestWithNoParams()
        {
            var expected = new Uri("https://friends.nico/api/v1/path/to/endpoint");
            var baseUrl = new Uri("https://friends.nico/");
            var path = "/api/v1/path/to/endpoint";
            var actual = ApiClientBase.CreateUrl(baseUrl, path, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateUriTestWithNoPath()
        {
            var expected = new Uri("https://friends.nico/");
            var baseUrl = new Uri("https://friends.nico/");
            var actual = ApiClientBase.CreateUrl(baseUrl, null, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async void CheckResponseWithStatusOKReturnsSameResponse()
        {
            var testResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };

            var result = await ApiClientBase.CheckResponse(testResponse);
            Assert.AreSame(testResponse, result);
        }

        [Test]
        public void CheckResponseWithFailStatusAndErrorBodyThrowsMastodonApiExceptionWithParsedError()
        {
            var jsonString = TestUtils.GetResource("Mastodon.API.Tests.Resources.get_error.json");
            var expectedError = new Error("Record not found");
            var testResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(jsonString)
            };
            Assert.That(async () => await ApiClientBase.CheckResponse(testResponse),
                Throws.Exception.TypeOf<MastodonApiException>()
                .With.Property("Error").EqualTo(expectedError)
                .With.Property("StatusCode").EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void CheckResponseWithFailStatusButNoParsableErrorBodyThrowsMastodonApiExceptionWithBodyInMessage()
        {
            var errorMessage = "History eraser button pressed";
            var testResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(errorMessage)
            };
            Assert.That(async () => await ApiClientBase.CheckResponse(testResponse),
                Throws.Exception.TypeOf<MastodonApiException>()
                .With.Property("Message").EqualTo($"Unexpected error returned from server: {errorMessage}")
                .With.Property("StatusCode").EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async void GetAsyncWithStatusAndMessage()
        {
            var message = "Hello";
            var statusCode = HttpStatusCode.OK;
            var mockHttp = MockHttpClient.Create(message, statusCode);
            var apiClient = new ApiClientBase(new Uri("http://example.com/"), mockHttp);

            var response = await apiClient.GetAsync("/test");

            Assert.AreEqual(message, await response.Content.ReadAsStringAsync());
            Assert.AreEqual(statusCode, response.StatusCode);
        }

        [Test]
        public void GetAsyncWithBadRequest()
        {
            var message = "This was bad";
            var statusCode = HttpStatusCode.BadRequest;
            var mockHttp = MockHttpClient.Create(message, statusCode);
            var apiClient = new ApiClientBase(new Uri("http://example.com/"), mockHttp);

            Assert.Throws<MastodonApiException>(async () => await apiClient.GetAsync("/test"));
        }
    }
}
