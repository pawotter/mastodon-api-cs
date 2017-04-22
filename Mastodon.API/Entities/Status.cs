using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Mastodon.API
{
    /// <summary>
    /// Status.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#status
    /// </summary>
    public class Status
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; }
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; }
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; }
        [JsonProperty(PropertyName = "account")]
        public Account Account { get; }
        [JsonProperty(PropertyName = "in_reply_to_id")]
        public string InReplyToId { get; }
        [JsonProperty(PropertyName = "in_reply_to_account_id")]
        public string InReplyToAccountId { get; }
        [JsonProperty(PropertyName = "reblog")]
        public Status Reblog { get; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; }
        [JsonProperty(PropertyName = "reblogs_count")]
        public int ReblogsCount { get; }
        [JsonProperty(PropertyName = "favourites_count")]
        public int FavouritesCount { get; }
        [JsonProperty(PropertyName = "reblogged")]
        public bool IsReblogged { get; }
        [JsonProperty(PropertyName = "favourited")]
        public bool IsFavourited { get; }
        [JsonProperty(PropertyName = "sensitive")]
        public bool IsSensitive { get; }
        [JsonProperty(PropertyName = "spoiler_text")]
        public string SpoilerText { get; }
        [JsonProperty(PropertyName = "visibility")]
        public StatusVisibility Visibility { get; }
        [JsonProperty(PropertyName = "media_attachments")]
        public IList<Attachment> MediaAttachments { get; }
        [JsonProperty(PropertyName = "mentions")]
        public IList<Mention> Mentions { get; }
        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; }
        [JsonProperty(PropertyName = "aplication")]
        public Application Application { get; }

        public Status(string id, string uri, Uri url, Account account, string inReplyToId, string inReplyToAccountId, Status reblog, string content, string createdAt, int reblogsCount, int favouritesCount, bool? reblogged, bool? favourited, bool? sensitive, string spoilerText, StatusVisibility visibility, IList<Attachment> mediaAttachments, IList<Mention> mentions, IList<Tag> tags, Application application)
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
            IsReblogged = reblogged ?? false;
            IsFavourited = favourited ?? false;
            IsSensitive = sensitive ?? false;
            SpoilerText = spoilerText;
            Visibility = visibility;
            MediaAttachments = mediaAttachments;
            Mentions = mentions;
            Tags = tags;
            Application = application;
        }

        public override string ToString()
        {
            return string.Format("[Status: Id={0}, Uri={1}, Url={2}, Account={3}, InReplyToId={4}, InReplyToAccountId={5}, Reblog={6}, Content={7}, CreatedAt={8}, ReblogsCount={9}, FavouritesCount={10}, IsReblogged={11}, IsFavourited={12}, IsSensitive={13}, SpoilerText={14}, Visibility={15}, MediaAttachments={16}, Mentions={17}, Tags={18}, Application={19}]", Id, Uri, Url, Account, InReplyToId, InReplyToAccountId, Reblog, Content, CreatedAt, ReblogsCount, FavouritesCount, IsReblogged, IsFavourited, IsSensitive, SpoilerText, Visibility, MediaAttachments, Mentions, Tags, Application);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Status;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(Uri, o.Uri) &&
                Equals(Url, o.Url) &&
                Equals(Account, o.Account) &&
                Equals(InReplyToId, o.InReplyToId) &&
                Equals(InReplyToAccountId, o.InReplyToAccountId) &&
                Equals(Reblog, o.Reblog) &&
                Equals(Content, o.Content) &&
                Equals(CreatedAt, o.CreatedAt) &&
                Equals(ReblogsCount, o.ReblogsCount) &&
                Equals(FavouritesCount, o.FavouritesCount) &&
                Equals(IsReblogged, o.IsReblogged) &&
                Equals(IsFavourited, o.IsFavourited) &&
                Equals(SpoilerText, o.SpoilerText) &&
                Equals(Visibility, o.Visibility) &&
                Object.SequenceEqual(MediaAttachments, o.MediaAttachments) &&
                Object.SequenceEqual(Mentions, o.Mentions) &&
                Object.SequenceEqual(Tags, o.Tags) &&
                Equals(Application, o.Application);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, Uri, Url, Account, InReplyToId, InReplyToAccountId, Reblog, Content, CreatedAt, ReblogsCount, FavouritesCount, IsReblogged, IsFavourited, IsSensitive, SpoilerText, Visibility, MediaAttachments, Mentions, Tags, Application);
        }
    }
}
