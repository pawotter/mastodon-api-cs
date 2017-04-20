using System;
namespace Mastodon.API
{
    /// <summary>
    /// Mention.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#mention
    /// </summary>
    public class Mention
    {
        public string Url { get; }
        public string Username { get; }
        public string Acct { get; }
        public string Id { get; }

        public Mention(string url, string username, string acct, string id)
        {
            Url = url;
            Username = username;
            Acct = acct;
            Id = id;
        }
    }
}
