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
        /// Updating the current user
        /// </summary>
        /// <returns>The current account.</returns>
        /// <param name="displayName">The name to display in the user's profile.</param>
        /// <param name="note">A new biography for the user.</param>
        /// <param name="base64EncodedAvater">A base64 encoded image to display as the user's avatar.</param>
        /// <param name="base64EncodedHeader">A base64 encoded image to display as the user's header image.</param>
        /// <param name="token">Token.</param>
        Task<Account> UpdateCurrentAccount(string displayName = null, string note = null, string base64EncodedAvater = null, string base64EncodedHeader = null, CancellationToken? token = null);

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

        /// <summary>
        /// Fetching a status.
        /// </summary>
        /// <returns>Status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Status> GetStatus(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting status context.
        /// </summary>
        /// <returns>The context.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Context> GetContext(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting a card associated with a status.
        /// </summary>
        /// <returns>The card.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Card> GetCard(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting who reblogged a status.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetRebloggedBy(string id, CancellationToken? token = null);

        /// <summary>
        /// Getting who favourited a status.
        /// </summary>
        /// <returns>Accounts.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Response<Account[]>> GetFavouritedBy(string id, CancellationToken? token = null);

        /// <summary>
        /// Posting a new status.
        /// </summary>
        /// <returns>The status.</returns>
        /// <param name="status">The text of the status.</param>
        /// <param name="inReplyTo">Local ID of the status you want to reply to.</param>
        /// <param name="mediaId">Media ID to attach to the status.</param>
        /// <param name="spoilerText">Text to be shown as a warning before the actual content.</param>
        /// <param name="visibility">Visibility</param>
        /// <param name="isSensitive">set this to mark the media of the status as NSFW.</param>
        /// <param name="token">Token.</param>
        Task<Status> PostStatus(string status, string inReplyTo = null, string mediaId = null, string spoilerText = null, StatusVisibility? visibility = null, bool? isSensitive = null, CancellationToken? token = null);

        /// <summary>
        /// Deleting a status.
        /// </summary>
        /// <returns>Nothing.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task DeleteStatus(string id, CancellationToken? token = null);

        /// <summary>
        /// Reblogging a status:
        /// </summary>
        /// <returns>Status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Status> Reblog(string id, CancellationToken? token = null);

        /// <summary>
        /// Unreblogging a status:
        /// </summary>
        /// <returns>Status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Status> Unreblog(string id, CancellationToken? token = null);

        /// <summary>
        /// Favouriting/ a status.
        /// </summary>
        /// <returns>Status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Status> Favourite(string id, CancellationToken? token = null);


        /// <summary>
        /// Unfavouriting a status.
        /// </summary>
        /// <returns>Status.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="token">Token.</param>
        Task<Status> Unfavourite(string id, CancellationToken? token = null);


        /// <summary>
        /// Retrieving a home timeline.
        /// </summary>
        /// <returns>The home timelines.</returns>
        /// <param name="link">Link.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetHomeTimelines(Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Retrieving a public timeline.
        /// </summary>
        /// <returns>The public timelines.</returns>
        /// <param name="isLocal">Is local.</param>
        /// <param name="link">Link.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetPublicTimelines(bool? isLocal = null, Link? link = null, CancellationToken? token = null);

        /// <summary>
        /// Retrieving a tag timeline.
        /// </summary>
        /// <returns>The tag timelines.</returns>
        /// <param name="hashtag">Hashtag.</param>
        /// <param name="isLocal">Is local.</param>
        /// <param name="link">Link.</param>
        /// <param name="token">Token.</param>
        Task<Response<Status[]>> GetTagTimelines(string hashtag, bool? isLocal = null, Link? link = null, CancellationToken? token = null);
    }
}
