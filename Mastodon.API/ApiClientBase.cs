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

        internal Task<HttpResponseMessage> PostAsync(string path, Dictionary<string, string> parameters, Dictionary<string, string> headers, CancellationToken? token)
        {
            var url = new Uri(string.Format("{0}{1}", baseUrl.AbsoluteUri, path));
            var request = createRequest(HttpMethod.Post, url, headers);
            if (parameters != null) request.Content = new FormUrlEncodedContent(parameters);
            return token.HasValue ? http.SendAsync(request, token.Value) : http.SendAsync(request);
        }

        HttpRequestMessage createRequest(HttpMethod method, Uri url, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(method, url);
            if (headers == null) return request;

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return request;
        }
    }
}
