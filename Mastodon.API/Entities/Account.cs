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
        public string Id { get; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; }
        [JsonProperty(PropertyName = "acct")]
        public string Acct { get; }
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; }
        [JsonProperty(PropertyName = "locked")]
        public bool IsLocked { get; }
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; }
        [JsonProperty(PropertyName = "followers_count")]
        public int FollowersCount { get; }
        [JsonProperty(PropertyName = "following_count")]
        public int FollowingCount { get; }
        [JsonProperty(PropertyName = "statuses_count")]
        public int StatusesCount { get; }
        [JsonProperty(PropertyName = "note")]
        public string Note { get; }
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; }
        [JsonProperty(PropertyName = "avater")]
        public Uri Avater { get; }
        [JsonProperty(PropertyName = "avater_static")]
        public Uri AvaterStatic { get; }
        [JsonProperty(PropertyName = "header")]
        public Uri Header { get; }
        [JsonProperty(PropertyName = "header_static")]
        public Uri HeaderStatic { get; }

        public Account(string id, string username, string acct, string displayName, bool locked, string createdAt, int followersCount, int followingCount, int statusesCount, string note, Uri url, Uri avater, Uri avaterStatic, Uri header, Uri headerStatic)
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
            Avater = avater;
            AvaterStatic = avaterStatic;
            Header = header;
            HeaderStatic = headerStatic;
        }

        public override string ToString()
        {
            return string.Format("[Account: Id={0}, Username={1}, Acct={2}, DisplayName={3}, isLocked={4}, CreatedAt={5}, FollowersCount={6}, FollowingCount={7}, StatusesCount={8}, Note={9}, Url={10}, Avater={11}, AvaterStatic={12}, Header={13}, HeaderStatic={14}]", Id, Username, Acct, DisplayName, IsLocked, CreatedAt, FollowersCount, FollowingCount, StatusesCount, Note, Url, Avater, AvaterStatic, Header, HeaderStatic);
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
                Equals(Avater, o.Avater) &&
                Equals(AvaterStatic, o.AvaterStatic) &&
                Equals(Header, o.Header) &&
                Equals(HeaderStatic, o.HeaderStatic);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id) ^
                         Object.GetHashCode(Username) ^
                         Object.GetHashCode(Acct) ^
                         Object.GetHashCode(DisplayName) ^
                         Object.GetHashCode(IsLocked) ^
                         Object.GetHashCode(CreatedAt) ^
                         Object.GetHashCode(IsLocked) ^
                         Object.GetHashCode(FollowingCount) ^
                         Object.GetHashCode(FollowersCount) ^
                         Object.GetHashCode(StatusesCount) ^
                         Object.GetHashCode(Note) ^
                         Object.GetHashCode(Url) ^
                         Object.GetHashCode(Avater) ^
                         Object.GetHashCode(AvaterStatic) ^
                         Object.GetHashCode(Header) ^
                         Object.GetHashCode(HeaderStatic);
        }
    }
}
