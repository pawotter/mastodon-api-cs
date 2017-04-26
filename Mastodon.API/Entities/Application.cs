using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Application.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#application
    /// </summary>
    public class Application
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "website")]
        public Uri Website { get; set; }

        internal Application() { }

        Application(string name, Uri webSite)
        {
            Name = name;
            Website = webSite;
        }

        public static Application create(string name, Uri webSite)
        {
            return new Application(name, webSite);
        }

        public override string ToString()
        {
            return string.Format("[Application: Name={0}, Website={1}]", Name, Website);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Application;
            if (o == null) return false;
            return Equals(Name, o.Name) &&
                Equals(Website, o.Website);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Name, Website);
        }
    }
}
