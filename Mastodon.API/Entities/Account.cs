using System;

namespace Mastodon.API
{
    /// <summary>
    /// Account.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#account
    /// </summary>
    public class Account
    {
        public int Id { get; }
        public string UserName { get; }
        public string Acct { get; }
        public string DisplayName { get; }
        public bool Locked { get; }
        public string CreatedAt { get; }
        public int FollowersCount { get; }
        public int FollowingCount { get; }
        public int StatusesCount { get; }
        public string Note { get; }
        public string Url { get; }
        public string Avater { get; }
        public string AvaterStatic { get; }
        public string Header { get; }
        public string HeaderStatic { get; }

        public Account(
            int id,
            string userName,
            string acct,
            string displayName,
            bool locked,
            string createdAt,
            int followersCount,
            int followingCount,
            int statusesCount,
            string note,
            string url,
            string avater,
            string avaterStatic,
            string header,
            string headerStatic
        )
        {
            Id = id;
            UserName = userName;
            Acct = acct;
            DisplayName = displayName;
            Locked = locked;
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
    }
}
