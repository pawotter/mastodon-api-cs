using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Account.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#account
    /// </summary>
    public class Account
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "acct")]
        public string Acct { get; set; }
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
        [JsonProperty(PropertyName = "locked")]
        public bool IsLocked { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty(PropertyName = "followers_count")]
        public int FollowersCount { get; set; }
        [JsonProperty(PropertyName = "following_count")]
        public int FollowingCount { get; set; }
        [JsonProperty(PropertyName = "statuses_count")]
        public int StatusesCount { get; set; }
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; set; }
        [JsonProperty(PropertyName = "avatar")]
        public Uri Avatar { get; set; }
        [JsonProperty(PropertyName = "avatar_static")]
        public Uri AvatarStatic { get; set; }
        [JsonProperty(PropertyName = "header")]
        public string Header { get; set; }
        [JsonProperty(PropertyName = "header_static")]
        public string HeaderStatic { get; set; }

        // 
        /// <summary>
        /// Initializes for JSON.NET
        /// </summary>
        internal Account() { }

        public Account(string id, string username, string acct, string displayName, bool locked, string createdAt, int followersCount, int followingCount, int statusesCount, string note, Uri url, Uri avater, Uri avatarStatic, string header, string headerStatic)
        {
            Id = id;
            Username = username;
            Acct = acct;
            DisplayName = displayName;
            IsLocked = locked;
            CreatedAt = createdAt;
            FollowersCount = followersCount;
            FollowingCount = followingCount;
            StatusesCount = statusesCount;
            Note = note;
            Url = url;
            Avatar = avater;
            AvatarStatic = avatarStatic;
            Header = header;
            HeaderStatic = headerStatic;
        }

        public static Account Create(string id, string username, string acct, string displayName, bool locked, string createdAt, int followersCount, int followingCount, int statusesCount, string note, Uri url, Uri avater, Uri avatarStatic, string header, string headerStatic)
        {
            return new Account(id, username, acct, displayName, locked, createdAt, followersCount, followingCount, statusesCount, note, url, avater, avatarStatic, header, headerStatic);
        }

        public override string ToString()
        {
            return string.Format("[Account: Id={0}, Username={1}, Acct={2}, DisplayName={3}, isLocked={4}, CreatedAt={5}, FollowersCount={6}, FollowingCount={7}, StatusesCount={8}, Note={9}, Url={10}, Avatar={11}, AvatarStatic={12}, Header={13}, HeaderStatic={14}]", Id, Username, Acct, DisplayName, IsLocked, CreatedAt, FollowersCount, FollowingCount, StatusesCount, Note, Url, Avatar, AvatarStatic, Header, HeaderStatic);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Account;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(Username, o.Username) &&
                Equals(Acct, o.Acct) &&
                Equals(DisplayName, o.DisplayName) &&
                Equals(IsLocked, o.IsLocked) &&
                Equals(CreatedAt, o.CreatedAt) &&
                Equals(FollowingCount, o.FollowingCount) &&
                Equals(FollowersCount, o.FollowersCount) &&
                Equals(StatusesCount, o.StatusesCount) &&
                Equals(Note, o.Note) &&
                Equals(Url, o.Url) &&
                Equals(Avatar, o.Avatar) &&
                Equals(AvatarStatic, o.AvatarStatic) &&
                Equals(Header, o.Header) &&
                Equals(HeaderStatic, o.HeaderStatic);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, Username, Acct, DisplayName, IsLocked, CreatedAt, FollowingCount, FollowersCount, StatusesCount, Note, Url, Avatar, AvatarStatic, Header, HeaderStatic);
        }
    }
}
