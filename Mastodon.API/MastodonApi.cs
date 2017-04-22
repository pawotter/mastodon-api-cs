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

        public MastodonApi(MastodonApiConfig config, HttpClient httpClient)
        {
            this.config = config;
            http = httpClient;
            http.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", config.AccessToken));
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
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, data, token.Value) : await http.PostAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Token>(task.Result));
        }

        public async Task<Account> GetAccount(string id, CancellationToken? token = null)
        {
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
            var path = "/api/v1/accounts/verify_credentials";
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.GetAsync(url, token.Value) : await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account>(task.Result));
        }

        public async Task<Response<Account[]>> GetFollowers(string id, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (link?.MaxId != null) parameters.Add(new KeyValuePair<string, object>("max_id", link?.MaxId.Value));
            if (link?.SinceId != null) parameters.Add(new KeyValuePair<string, object>("since_id", link?.SinceId.Value));
            if (limit != null) parameters.Add(new KeyValuePair<string, object>("limit", limit));
            var path = string.Format("/api/v1/accounts/{0}/followers", id);
            var url = new Uri(string.Format("{0}{1}{2}", config.InstanceBaseUrl, path, parameters.AsQueryString()));
            var response = token.HasValue ? await http.GetAsync(url, token.Value) : await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Account[]>> GetFollowing(string id, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (link?.MaxId != null) parameters.Add(new KeyValuePair<string, object>("max_id", link?.MaxId.Value));
            if (link?.SinceId != null) parameters.Add(new KeyValuePair<string, object>("since_id", link?.SinceId.Value));
            if (limit != null) parameters.Add(new KeyValuePair<string, object>("limit", limit));
            var path = string.Format("/api/v1/accounts/{0}/following", id);
            var url = new Uri(string.Format("{0}{1}{2}", config.InstanceBaseUrl, path, parameters.AsQueryString()));
            var response = token.HasValue ? await http.GetAsync(url, token.Value) : await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Status[]>> GetStatuses(string id, bool isOnlyMedia = false, bool isExcludeReplies = false, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (isOnlyMedia) parameters.Add(new KeyValuePair<string, object>("only_media", "1"));
            if (isExcludeReplies) parameters.Add(new KeyValuePair<string, object>("exclude_replies", "1"));
            if (link?.MaxId != null) parameters.Add(new KeyValuePair<string, object>("max_id", link?.MaxId.Value));
            if (link?.SinceId != null) parameters.Add(new KeyValuePair<string, object>("since_id", link?.SinceId.Value));
            if (limit != null) parameters.Add(new KeyValuePair<string, object>("limit", limit));
            var path = string.Format("/api/v1/accounts/{0}/statuses", id);
            var url = new Uri(string.Format("{0}{1}{2}", config.InstanceBaseUrl, path, parameters.AsQueryString()));
            var response = token.HasValue ? await http.GetAsync(url, token.Value) : await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        public async Task<Relationship> Follow(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/follow", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, null, token.Value) : await http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unfollow(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/unfollow", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, null, token.Value) : await http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Block(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/block", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, null, token.Value) : await http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unblock(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/unblock", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, null, token.Value) : await http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Mute(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/mute", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, null, token.Value) : await http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unmute(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/unmute", id);
            var url = new Uri(string.Format("{0}{1}", config.InstanceBaseUrl, path));
            var response = token.HasValue ? await http.PostAsync(url, null, token.Value) : await http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }
    }
}
