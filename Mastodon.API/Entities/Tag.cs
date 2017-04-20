using System;
namespace Mastodon.API
{
    /// <summary>
    /// Tag.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#tag
    /// </summary>
    public class Tag
    {
        public string Name { get; }
        public string Url { get; }

        public Tag(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
