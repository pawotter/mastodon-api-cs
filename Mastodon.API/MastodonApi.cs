using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Mastodon.API
{
    public class MastodonApi : IMastodonApi, IDisposable
    {
        readonly ApiClientBase apiBase;
        readonly MastodonApiConfig config;
        readonly Dictionary<string, string> authorizationHeader;

        public MastodonApi(MastodonApiConfig config, HttpClient httpClient = null)
        {
            this.config = config;
            apiBase = new ApiClientBase(config.InstanceUrl, httpClient ?? MastodonApi.GetDefaultHttpClient());
            authorizationHeader = new Dictionary<string, string> { { "Authorization", $"Bearer {config.AccessToken}" } };
        }

        public override string ToString()
        {
            return $"[MastodonApi: config={config}]";
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
            var path = $"/api/v1/accounts/{id}";
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

        public async Task<Account> UpdateCurrentAccount(string displayName = null, string note = null, string base64EncodedAvater = null, string base64EncodedHeader = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, string>();
            if (displayName != null) parameters.Add("display_name", displayName);
            if (note != null) parameters.Add("note", note);
            if (base64EncodedAvater != null) parameters.Add("avater", base64EncodedAvater);
            if (base64EncodedHeader != null) parameters.Add("header", base64EncodedHeader);
            var path = "/api/v1/accounts/update_credentials";
            var response = await apiBase.PatchAsync(path, parameters, authorizationHeader, token);
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
            var path = $"/api/v1/accounts/{id}/followers";
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
            var path = $"/api/v1/accounts/{id}/following";
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
            var path = $"/api/v1/accounts/{id}/statuses";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        public async Task<Relationship> Follow(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/accounts/{id}/follow";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unfollow(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/accounts/{id}/unfollow";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Block(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/accounts/{id}/block";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unblock(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/accounts/{id}/unblock";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Mute(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/accounts/{id}/mute";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Relationship>(task.Result));
        }

        public async Task<Relationship> Unmute(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/accounts/{id}/unmute";
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
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
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
            var path = $"/api/v1/follow_requests/{id}/authorize";
            await apiBase.PostAsync(path, null, authorizationHeader, token);
        }

        public async Task RejectFollowRequests(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/follow_requests/{id}/reject";
            await apiBase.PostAsync(path, null, authorizationHeader, token);
        }

        public async Task<Account> FollowRemoteUser(string uri, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, string> { { "uri", uri } };
            var path = "/api/v1/follows";
            var response = await apiBase.PostAsync(path, parameters, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account>(task.Result));
        }

        public async Task<Instance> GetInstance(CancellationToken? token = null)
        {
            var path = "/api/v1/instance";
            // Does not require authentication.
            var response = await apiBase.GetAsync(path, null, null, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Instance>(task.Result));
        }

        public async Task<Attachment> Upload(string base64EncodedMedia, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, string> { { "file", base64EncodedMedia } };
            var path = "/api/v1/media";
            var response = await apiBase.PostAsync(path, parameters, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Attachment>(task.Result));
        }

        public async Task<Response<Account[]>> GetMutes(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/mutes";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Notification> GetNotification(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/notifications/{id}";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Notification>(task.Result));
        }

        public async Task<Response<Notification[]>> GetNotifications(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/notifications";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Notification[]>(task.Result));
            return new Response<Notification[]>(resource, response);
        }

        public async Task ClearNotifications(CancellationToken? token = null)
        {
            var path = "/api/v1/notifications/clear";
            await apiBase.PostAsync(path, null, authorizationHeader, token);
        }

        public async Task<Response<Report[]>> GetReports(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/reports";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Report[]>(task.Result));
            return new Response<Report[]>(resource, response);
        }

        public async Task<Report> Report(string accountId, string statusId, string comment, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, string>
            {
                { "account_id", accountId },
                { "status_ids", statusId },
                { "comment", comment }
            };
            var path = "/api/v1/reports";
            var response = await apiBase.PostAsync(path, parameters, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Report>(task.Result));
        }

        public async Task<Response<Results>> Search(string query, bool resolve = true, int? limit = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object> { { "q", query } };
            if (resolve) parameters.Add("resolve", "1");
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (limit != null) parameters.Add("limit", limit);
            var path = "/api/v1/search";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Results>(task.Result));
            return new Response<Results>(resource, response);
        }

        public async Task<Status> GetStatus(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status>(task.Result));
        }

        public async Task<Context> GetContext(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/context";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Context>(task.Result));
        }

        public async Task<Card> GetCard(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/card";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Card>(task.Result));
        }

        public async Task<Response<Account[]>> GetRebloggedBy(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/reblogged_by";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Response<Account[]>> GetFavouritedBy(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/favourited_by";
            var response = await apiBase.GetAsync(path, null, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Account[]>(task.Result));
            return new Response<Account[]>(resource, response);
        }

        public async Task<Status> PostStatus(string status, string inReplyTo = null, string mediaId = null, string spoilerText = null, StatusVisibility? visibility = null, bool? isSensitive = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, string> { { "status", status } };
            if (inReplyTo != null) parameters.Add("in_reply_to", inReplyTo);
            if (mediaId != null) parameters.Add("media_ids", mediaId);
            if (isSensitive ?? false) parameters.Add("sensitive", "1");
            if (spoilerText != null) parameters.Add("spoiler_text", spoilerText);
            if (visibility != null) parameters.Add("visibility", visibility.Value.Value());
            var path = "/api/v1/statuses";
            var response = await apiBase.PostAsync(path, parameters, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status>(task.Result));
        }

        public async Task DeleteStatus(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}";
            await apiBase.DeleteAsync(path, null, authorizationHeader, token);
        }

        public async Task<Status> Reblog(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/reblog";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status>(task.Result));
        }

        public async Task<Status> Unreblog(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/unreblog";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status>(task.Result));
        }

        public async Task<Status> Favourite(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/favourite";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status>(task.Result));
        }

        public async Task<Status> Unfavourite(string id, CancellationToken? token = null)
        {
            var path = $"/api/v1/statuses/{id}/unfavourite";
            var response = await apiBase.PostAsync(path, null, authorizationHeader, token);
            return await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status>(task.Result));
        }

        public async Task<Response<Status[]>> GetHomeTimelines(Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            var path = "/api/v1/timelines/home";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        public async Task<Response<Status[]>> GetPublicTimelines(bool? isLocal = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (isLocal ?? false) parameters.Add("local", "1");
            var path = "/api/v1/timelines/public";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        public async Task<Response<Status[]>> GetTagTimelines(string hashtag, bool? isLocal = null, Link? link = null, CancellationToken? token = null)
        {
            var parameters = new Dictionary<string, object>();
            if (link?.MaxId != null) parameters.Add("max_id", link?.MaxId.Value);
            if (link?.SinceId != null) parameters.Add("since_id", link?.SinceId.Value);
            if (isLocal ?? false) parameters.Add("local", "1");
            var path = $"/api/v1/timelines/tag/{hashtag}";
            var response = await apiBase.GetAsync(path, parameters, authorizationHeader, token);
            var resource = await response
                .Content.ReadAsStringAsync()
                .ContinueWith((task) => JsonConvert.DeserializeObject<Status[]>(task.Result));
            return new Response<Status[]>(resource, response);
        }

        internal static HttpClient GetDefaultHttpClient()
        {
            return new HttpClient();
        }

        public void Dispose()
        {
            apiBase.Dispose();
        }
    }
}
