using System;
namespace Mastodon.API
{
    /// <summary>
    /// Relationship.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#relationship
    /// </summary>
    public class Relationship
    {
        public string Id { get; }
        public bool IsFollowing { get; }
        public bool IsFollowedBy { get; }
        public bool IsBlocking { get; }
        public bool IsMuting { get; }
        public bool IsRequested { get; }

        public Relationship(string id, bool following, bool followedBy, bool blocking, bool muting, bool requested)
        {
            Id = id;
            IsFollowing = following;
            IsFollowedBy = followedBy;
            IsBlocking = blocking;
            IsMuting = muting;
            IsRequested = requested;
        }

    }
}
