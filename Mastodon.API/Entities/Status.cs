using System;
using System.Collections.Generic;

namespace Mastodon.API
{
    /// <summary>
    /// Status.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#status
    /// </summary>
    public class Status
    {
        public string Id { get; }
        public string Uri { get; }
        public string Url { get; }
        public Account Account { get; }
        public string InReplyToId { get; }
        public string InReplyToAccountId { get; }
        public Status Reblog { get; }
        public string Content { get; }
        public string CreatedAt { get; }
        public int ReblogsCount { get; }
        public int FavouritesCount { get; }
        public bool IsReblogged { get; }
        public bool IsFavourited { get; }
        public bool IsSensitive { get; }
        public string SpoilerText { get; }
        public string Visibility { get; }
        public IList<Attachment> MediaAttachments { get; }
        public IList<Mention> Mentions { get; }
        public IList<Tag> Tags { get; }
        public Application Application { get; }

        public Status(string id, string uri, string url, Account account, string inReplyToId, string inReplyToAccountId, Status reblog, string content, string createdAt, int reblogsCount, int favouritesCount, bool reblogged, bool favourited, bool sensitive, string spoilerText, string visibility, IList<Attachment> mediaAttachments, IList<Mention> mentions, IList<Tag> tags, Application application)
        {
            Id = id;
            Uri = uri;
            Url = url;
            Account = account;
            InReplyToId = inReplyToId;
            InReplyToAccountId = inReplyToAccountId;
            Reblog = reblog;
            Content = content;
            CreatedAt = createdAt;
            ReblogsCount = reblogsCount;
            FavouritesCount = favouritesCount;
            IsReblogged = reblogged;
            IsFavourited = favourited;
            IsSensitive = sensitive;
            SpoilerText = spoilerText;
            Visibility = visibility;
            MediaAttachments = mediaAttachments;
            Mentions = mentions;
            Tags = tags;
            Application = application;
        }
    }
}
