using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Relationship.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#relationship
    /// </summary>
    public class Relationship
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; }
        [JsonProperty(PropertyName = "following")]
        public bool IsFollowing { get; }
        [JsonProperty(PropertyName = "followed_by")]
        public bool IsFollowedBy { get; }
        [JsonProperty(PropertyName = "blocking")]
        public bool IsBlocking { get; }
        [JsonProperty(PropertyName = "muting")]
        public bool IsMuting { get; }
        [JsonProperty(PropertyName = "requested")]
        public bool IsRequested { get; }

        public Relationship(string id, bool following, bool followed_by, bool blocking, bool muting, bool requested)
        {
            Id = id;
            IsFollowing = following;
            IsFollowedBy = followed_by;
            IsBlocking = blocking;
            IsMuting = muting;
            IsRequested = requested;
        }

        public override string ToString()
        {
            return string.Format("[Relationship: Id={0}, IsFollowing={1}, IsFollowedBy={2}, IsBlocking={3}, IsMuting={4}, IsRequested={5}]", Id, IsFollowing, IsFollowedBy, IsBlocking, IsMuting, IsRequested);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Relationship;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(IsFollowing, o.IsFollowing) &&
                Equals(IsFollowedBy, o.IsFollowedBy) &&
                Equals(IsBlocking, o.IsBlocking) &&
                Equals(IsMuting, o.IsMuting) &&
                Equals(IsRequested, o.IsRequested);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, IsFollowing, IsFollowedBy, IsBlocking, IsMuting, IsRequested);
        }
    }
}
