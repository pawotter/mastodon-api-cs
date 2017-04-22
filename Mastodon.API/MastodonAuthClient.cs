using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Mastodon.API
{
    public class MastodonAuthClient
    {
        readonly ApiClientBase apiBase;

        public MastodonAuthClient(Uri instanceUrl, HttpClient httpClient)
        {
            apiBase = new ApiClientBase(instanceUrl, httpClient);
        }

        /// <summary>
        /// Creates the app on Mastodon instance.
        /// </summary>
        /// <returns>MastodonApp.</returns>
        /// <param name="clientName">Client name.</param>
        /// <param name="redirectUris">Redirect uris.</param>
        /// <param name="scope">Scope.</param>
        /// <param name="token">Token.</param>
        public async Task<MastodonApp> CreateApp(string clientName, Uri redirectUris, OAuthAccessScope scope, CancellationToken? token = null)
        {
            var data = new Dictionary<string, string> {
                { "client_name", clientName },
                { "redirect_uris", redirectUris.AbsoluteUri },
                { "scope", scope.Value },
            };
            var response = await apiBase.PostAsync("/api/v1/apps", data, null, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<MastodonApp>(task.Result));
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
            var data = new Dictionary<string, string> {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", scope.Value },
                { "grant_type", "password" },
                { "username", username },
                { "password", password }
            };
            var response = await apiBase.PostAsync("/oauth/token", data, null, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Token>(task.Result));
        }
    }
}
