using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mastodon.API
{
    public class MastodonApi : IMastodonApi
    {
        readonly MastodonApiConfig config;
        readonly HttpClient http;
        string accessToken = "";

        public MastodonApi(MastodonApiConfig config, HttpClient httpClient)
        {
            this.config = config;
            http = httpClient;
        }

        public override string ToString()
        {
            return string.Format("[MastodonApi: config={0}]", config);
        }

        public override bool Equals(object obj)
        {
            var o = obj as MastodonApi;
            if (o == null) return false;
            return Equals(config, o.config) &&
                Equals(http, o.http);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(config, http);
        }

        public async Task<Token> GetOAuthToken(string username, string password, OAuthAccessScope scope, CancellationToken? token = null)
        {
            var data = new FormUrlEncodedContent(new Dictionary<string, string> {
                { "client_id", config.ClientId },
                { "client_secret", config.ClietnSecret },
                { "scope", scope.Value },
                { "grant_type", "password" },
                { "username", username },
                { "password", password }
            });
            var path = "/oauth/token";
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, data, token.Value) : await http.PostAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Token>(task.Result));
        }

        public async Task<Account> GetAccount(string id, CancellationToken? token = null)
        {
            http.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            var path = string.Format("/api/v1/accounts/{0}", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.GetAsync(url, token.Value) : await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account>(task.Result));
        }

        public async Task<Account> GetCurrentAccount(CancellationToken? token = null)
        {
            http.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            var path = "/api/v1/accounts/verify_credentials";
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.GetAsync(url, token.Value) : await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account>(task.Result));
        }
    }
}
