using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Mastodon.API
{
    public class MastodonApi : IMastodonApi
    {
        readonly ApiClientBase apiBase;
        readonly MastodonApiConfig config;
        readonly Dictionary<string, string> authorizationHeader;

        public MastodonApi(MastodonApiConfig config, HttpClient httpClient)
        {
            this.config = config;
            apiBase = new ApiClientBase(config.InstanceUrl, httpClient);
            authorizationHeader = new Dictionary<string, string> { { "Authorization", string.Format("Bearer {0}", config.AccessToken) } };
        }

        public override string ToString()
        {
            return string.Format("[MastodonApi: config={0}]", config);
        }

        public override bool Equals(object obj)
        {
            var o = obj as MastodonApi;
            if (o == null) return false;
            return Equals(apiBase, o.apiBase) &&
                Equals(config, o.config);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(apiBase, config);
        }

        public async Task<Account> GetAccount(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}", id);
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account>(task.Result));
        }

        public async Task<Account> GetCurrentAccount(CancellationToken? token = null)
        {
            var path = "/api/v1/accounts/verify_credentials";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account>(task.Result));
        }

        public async Task<Response<Account[]>> GetFollowers(string id, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (limit != null) parameters.Add("limit", limit);
            var path = string.Format("/api/v1/accounts/{0}/followers", id);
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Account[]>> GetFollowing(string id, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (limit != null) parameters.Add("limit", limit);
            var path = string.Format("/api/v1/accounts/{0}/following", id);
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Status[]>> GetStatuses(string id, bool isOnlyMedia = false, bool isExcludeReplies = false, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (isOnlyMedia) parameters.Add("only_media", "1");
            if (isExcludeReplies) parameters.Add("exclude_replies", "1");
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (limit != null) parameters.Add("limit", limit);
            var path = string.Format("/api/v1/accounts/{0}/statuses", id);
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        public async Task<Relationship> Follow(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/follow", id);
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unfollow(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/unfollow", id);
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Block(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/block", id);
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unblock(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/unblock", id);
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Mute(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/mute", id);
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unmute(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/accounts/{0}/unmute", id);
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> GetRelationship(string id, CancellationToken? token = null)
        {
            return await GetRelationships(new string[] { id }, token)
                .ContinueWith((task) => task.Result.First());
        }

        public async Task<Relationship[]> GetRelationships(string[] ids, CancellationToken? token = null)
        {
            var idArray = ids ?? new string[] { };
            var parameters = idArray.Select(x => new KeyValuePair<string, object>("id[]", x));
            var path = "/api/v1/accounts/relationships";
            var response = await apiBase.GetAsyncWithArrayParams(path, parameters, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship[]>(task.Result));
        }

        public async Task<Response<Account[]>> SearchAccounts(string query, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("q", query);
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (limit != null) parameters.Add("limit", limit);
            var path = "/api/v1/accounts/search";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Account[]>> GetBlocks(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/blocks";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Status[]>> GetFavourites(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/favourites";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        public async Task<Response<Account[]>> GetFollowRequests(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/follow_requests";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task AuthorizeFollowRequests(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/follow_requests/{0}/authorize", id);
            await apiBase.PostAsync(path, null, authorizationHeader, token);
        }

        public async Task RejectFollowRequests(string id, CancellationToken? token = null)
        {
            var path = string.Format("/api/v1/follow_requests/{0}/reject", id);
            await apiBase.PostAsync(path, null, authorizationHeader, token);
        }
    }
}
