using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mastodon.API
{
    public class MastodonAuthClient
    {
        readonly Uri instanceUrl;
        readonly HttpClient http;

        public MastodonAuthClient(Uri instanceUrl, HttpClient httpClient)
        {
            this.instanceUrl = instanceUrl;
            http = httpClient;
        }

        /// <summary>
        /// Return an OAuth token.
        /// DO NOT USE IN APP.
        /// </summary>
        /// <returns>OAuth token.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="token">Token.</param>
        public async Task<Token> GetOAuthToken(string clientId, string clientSecret, string username, string password, OAuthAccessScope scope, CancellationToken? token = null)
        {
            var data = new FormUrlEncodedContent(new Dictionary<string, string> {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", scope.Value },
                { "grant_type", "password" },
                { "username", username },
                { "password", password }
            });
            var path = "/oauth/token";
            var url = new Uri(string.Format("{0}{1}", instanceUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, data, token.Value) : await http.PostAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Token>(task.Result));
        }
    }
}
