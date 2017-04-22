using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mastodon.API
{
    class ApiClientBase
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
            var url = new Uri(string.Format("{0}{1}{2}", baseUrl.AbsoluteUri, path, parameters.AsQueryString()));
            var request = createRequest(HttpMethod.Get, url, headers);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        internal async Task<HttpResponseMessage> GetAsyncWithArrayParams(string path, IEnumerable<KeyValuePair<string, object>> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = new Uri(string.Format("{0}{1}{2}", baseUrl.AbsoluteUri, path, parameters.AsQueryString()));
            var request = createRequest(HttpMethod.Get, url, headers);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        internal async Task<HttpResponseMessage> PostAsync(string path, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = new Uri(string.Format("{0}{1}", baseUrl.AbsoluteUri, path));
            var request = createRequest(HttpMethod.Post, url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        internal async Task<HttpResponseMessage> PatchAsync(string path, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = new Uri(string.Format("{0}{1}", baseUrl.AbsoluteUri, path));
            var request = createRequest(new HttpMethod("PATCH"), url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        internal async Task<HttpResponseMessage> DeleteAsync(string path, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, CancellationToken? token = null)
        {
            var url = new Uri(string.Format("{0}{1}", baseUrl.AbsoluteUri, path));
            var request = createRequest(HttpMethod.Delete, url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            var response = token.HasValue ? await http.SendAsync(request, token.Value) : await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }


        HttpRequestMessage createRequest(HttpMethod method, Uri url, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(method, url);
            if (headers == null) return request;
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return request;
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
    }
}
