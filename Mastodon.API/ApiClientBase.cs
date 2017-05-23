using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Mastodon.API
{
    class ApiClientBase : IDisposable
    {
        readonly Uri baseUrl;
        readonly HttpClient http;

        internal ApiClientBase(Uri baseUrl, HttpClient http)
        {
            this.baseUrl = baseUrl;
            this.http = http;
        }

        internal async Task<HttpResponseMessage> GetAsync(string path, IDictionary<string, object> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = CreateUrl(baseUrl, path, parameters);
            var request = CreateRequest(HttpMethod.Get, url, headers);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            return await CheckResponse(response);
        }

        internal async Task<HttpResponseMessage> GetAsyncWithArrayParams(string path, IEnumerable<KeyValuePair<string, object>> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = CreateUrl(baseUrl, path, parameters);
            var request = CreateRequest(HttpMethod.Get, url, headers);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            return await CheckResponse(response);
        }

        internal async Task<HttpResponseMessage> PostAsync(string path, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = CreateUrl(baseUrl, path, null);
            var request = CreateRequest(HttpMethod.Post, url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            return await CheckResponse(response);
        }

        internal async Task<HttpResponseMessage> PatchAsync(string path, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = CreateUrl(baseUrl, path, null);
            var request = CreateRequest(new HttpMethod("PATCH"), url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            return await CheckResponse(response);
        }

        internal async Task<HttpResponseMessage> DeleteAsync(string path, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = CreateUrl(baseUrl, path, null);
            var request = CreateRequest(HttpMethod.Delete, url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            return await CheckResponse(response);
        }

        HttpRequestMessage CreateRequest(HttpMethod method, Uri url, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(method, url);
            if (headers == null) return request;
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return request;
        }

        internal static Uri CreateUrl(Uri baseUri, string path, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var p = path ?? "";
            var q = parameters?.AsQueryString() ?? "";
            return new Uri(baseUri, $"{p}{q}");
        }

        public override string ToString()
        {
            return string.Format("[ApiClientBase: baseUrl={0}, http={1}]", baseUrl, http);
        }

        public override bool Equals(object obj)
        {
            var o = obj as ApiClientBase;
            if (o == null) return false;
            return Equals(baseUrl, o.baseUrl) &&
                Equals(http, o.http);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(baseUrl, http);
        }

        internal static async Task<HttpResponseMessage> CheckResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    var error = JsonConvert.DeserializeObject<Error>(responseBody);
                    throw new MastodonApiException(response.StatusCode, error);
                }
                catch (JsonReaderException)
                {
                    // There is a possibility that the object could not be deserialized
                    throw new MastodonApiException(response.StatusCode, $"Unexpected error returned from server: {responseBody}");
                }
            }
            return response;
        }

        public void Dispose()
        {
            http.Dispose();
        }
    }
}
