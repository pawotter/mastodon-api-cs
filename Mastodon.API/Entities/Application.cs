using System;

namespace Mastodon.API
{
    /// <summary>
    /// Application.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#application
    /// </summary>
    public class Application
    {
        public string Name { get; }
        public string WebSite { get; }

        public Application(string name, string webSite)
        {
            Name = name;
            WebSite = webSite;
        }
    }
}
