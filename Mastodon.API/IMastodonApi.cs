using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mastodon.API
{
    public interface IMastodonApi
    {
        /// <summary>
        /// Returns an Account.
        /// </summary>
        /// <returns>The account.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Account> GetAccount(string id, CancellationToken? token = null);

        /// <summary>
        /// Returns the authenticated user's Account.
        /// </summary>
        /// <returns>The current account.</returns>
        /// <param name="token">Token.</param>
        Task<Account> GetCurrentAccount(CancellationToken? token = null);

        /// <summary>
        /// Getting an account's followers.
        /// </summary>
        /// <returns>The followers.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFollowers(string id, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's following.
        /// </summary>
        /// <returns>The follwing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>      
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFollowing(string id, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's statuses.
        /// </summary>
        /// <returns>The status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetStatuses(string id, bool isOnlyMedia = false, bool isExcludeReplies = false, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Following an account:
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Follow(string id, CancellationToken? token = null);

        /// <summary>
        /// Unfollowing an account:
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Unfollow(string id, CancellationToken? token = null);

        /// <summary>
        /// Blocking an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Block(string id, CancellationToken? token = null);


        /// <summary>
        /// Unblocking an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Unblock(string id, CancellationToken? token = null);

        /// <summary>
        /// Mute an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Mute(string id, CancellationToken? token = null);

        /// <summary>
        /// Unmute an account
        /// </summary>
        /// <returns>Relationship.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> Unmute(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's relationship.
        /// </summary>
        /// <returns>The relationships</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Relationship> GetRelationship(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting an account's relationships
        /// </summary>
        /// <returns>The relationships.</returns>
        /// <param name="ids">Identifiers.</param>
        /// <param name="token">Token.</param>
        Task<Relationship[]> GetRelationships(string[] ids, CancellationToken? token = null);

        /// <summary>
        /// Searching for accounts.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="query">Query.</param>
        /// <param name="limit">Maximum number of accounts to get (Default 40, Max 80)</param>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> SearchAccounts(string query, int? limit = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's blocks.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetBlocks(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's favourites.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetFavourites(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Fetching a list of follow requests.
        /// </summary>
        /// <returns>The follow requests.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFollowRequests(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Authorizing follow requests.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task AuthorizeFollowRequests(string id, CancellationToken? token = null);

        /// <summary>
        /// Rejecting follow requests.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task RejectFollowRequests(string id, CancellationToken? token = null);

        /// <summary>
        /// Following a remote user.
        /// </summary>
        /// <returns>The local representation of the followed account, as an Account.</returns>
        /// <param name="uri">URI.</param>
        /// <param name="token">Token.</param>
        Task<Account> FollowRemoteUser(string uri, CancellationToken? token = null);

        /// <summary>
        /// Getting instance information.
        /// </summary>
        /// <returns>The current Instance.</returns>
        /// <param name="token">Token.</param>
        Task<Instance> GetInstance(CancellationToken? token = null);

        /// <summary>
        /// Uploading a media attachment.
        /// </summary>
        /// <returns>An Attachment that can be used when creating a status.</returns>
        /// <param name="base64EncodedMedia">Base64 encoded media.</param>
        /// <param name="token">Token.</param>
        Task<Attachment> Upload(string base64EncodedMedia, CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's mutes.
        /// </summary>
        /// <returns>An array of Accounts muted by the authenticated user.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetMutes(Link? link = null, CancellationToken? token = null);


        /// <summary>
        /// Fetching a user's notification.
        /// </summary>
        /// <returns>The Notification for the authenticated user.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Notification> GetNotification(string id, CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's notifications.
        /// </summary>
        /// <returns>A list of Notifications for the authenticated user.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Notification[]>> GetNotifications(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Clearing notifications.
        /// Deletes all notifications from the Mastodon server for the authenticated user. Returns an empty object.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <param name="token">Token.</param>
        Task ClearNotifications(CancellationToken? token = null);

        /// <summary>
        /// Fetching a user's reports.
        /// </summary>
        /// <returns>A list of Reports made by the authenticated user.</returns>
        /// <param name="link">MaxId and SinceId are usually get from the Link header.</param>
        /// <param name="token">Token.</param>
        Task<Response<Report[]>> GetReports(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Reporting a user.
        /// </summary>
        /// <returns>The report.</returns>
        /// <param name="accountId">Account identifier.</param>
        /// <param name="statusId">Status identifier.</param>
        /// <param name="comment">Comment.</param>
        /// <param name="token">Token.</param>
        Task<Report> Report(string accountId, string statusId, string comment, CancellationToken? token = null);

        /// <summary>
        /// Searching for content.
        /// </summary>
        /// <returns>If q is a URL, Mastodon will attempt to fetch the provided account or status. Otherwise, it will do a local account and hashtag search.</returns>
        /// <param name="query">Query.</param>
        /// <param name="resolve">If set to <c>true</c> resolve.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="link">Link.</param>
        /// <param name="token">Token.</param>
        Task<Response<Results>> Search(string query, bool resolve = true, int? limit = null, Link? link = null, CancellationToken? token = null);
    }
}
