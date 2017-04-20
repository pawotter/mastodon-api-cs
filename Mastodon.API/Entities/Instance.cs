using System;
namespace Mastodon.API
{
    /// <summary>
    /// Instance.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#instance
    /// </summary>
    public class Instance
    {
        public string Uri { get; }
        public string Title { get; }
        public string Description { get; }
        public string Email { get; }

        public Instance(string uri, string title, string description, string email)
        {
            Uri = uri;
            Title = title;
            Description = description;
            Email = email;
        }
    }
}
